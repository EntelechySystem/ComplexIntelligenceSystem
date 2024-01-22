namespace EntelechySystem.ComplexIntelligenceSystem.Core;

using System.Collections.Generic;
using System.Linq;

public enum StateOfScheduleEnum
{
    collecting,
    running
}

public class ProcessMachine

{
    [System.Serializable]
    public class ProcessState
    {
        public string process_state;
    }

    public static Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>> Process(Agents node, Agent A, AgentDataCollection A_data, Dictionary<string, object> para, Dictionary<string, object> env)
    {
        if (Enumerable.SequenceEqual(node.attribute.node_type, new List<string>() {"content node"}) && Enumerable.SequenceEqual(node.attribute.content_type, new List<string>() {"algorithm content"}))
        {
            var b = (A.BB.on | A.BB.off);
            var ib = (A.BB.on | A.BB.off) & (A.BB.on | A.BB.off).T;

            if (env["state_of_schedule"].Equals(StateOfScheduleEnum.collecting))
            {
                env = Scheduler.Schedule(env, node);
                if (env["state_of_schedule"].Equals(StateOfScheduleEnum.running))
                {
                    var result = Executer.ExecuteTerminalEntity(A, b, ib, para, env, node);
                    A = result.Item1;
                    env = result.Item2;
                }
            }

            var result2 = Collector.Collect(A, A_data, env);
            A_data = result2.Item1;
            env = result2.Item2;

            var processState = new ProcessState() {process_state = "has processed"};
            node.attribute.other["process_state"] = processState;

            return new Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>>(node, A, A_data, para, env);
        }

        if ((Enumerable.SequenceEqual(node.attribute.node_type, new List<string>() {"process node", "container node"}) && Enumerable.SequenceEqual(node.attribute.content_type, new List<string>() {"algorithm content"})) || (Enumerable.SequenceEqual(node.attribute.node_type, new List<string>() {"process node", "container node"}) && Enumerable.SequenceEqual(node.attribute.content_type, new List<string>() {"model content"})))
        {
            var processState = new ProcessState() {process_state = "process now"};
            node.attribute.other["process_state"] = processState;

            var entity = node.content;
            var innerNodeName = entity.container["node_START"].attribute.entity_name;
            var innerNode = entity.container[innerNodeName];
            var result3 = Executer.ExecuteBranchEntity(innerNode, A, A_data, para, env);
            innerNode = result3.Item1;
            A = result3.Item2;
            A_data = result3.Item3;
            para = result3.Item4;
            env = result3.Item5;
            var innerProcessState = new ProcessState() {process_state = "has processed"};
            innerNode.attribute.other["process_state"] = innerProcessState;

            var innerForwardNode = innerNode.process[0]["direction"];
            Logging.Debug("        方向是【节点：" + innerForwardNode.attribute.entity_name + "，算法：" + innerForwardNode.content.attribute.entity_name + " " + innerForwardNode.content.attribute.text_name + "】");

            while (!((innerForwardNode.attribute.other["process_state"].Equals(new ProcessState() {process_state = "has processed"})) && innerForwardNode.attribute.entity_name.Equals("node_END")))
            {
                if (Enumerable.SequenceEqual(innerForwardNode.attribute.node_type, new List<string>() {"content node"}) && Enumerable.SequenceEqual(innerForwardNode.attribute.content_type, new List<string>() {"algorithm content"}))
                {
                    var result4 = Executer.ExecuteTerminalEntity(innerForwardNode, A, A_data, para, env);
                    innerForwardNode = result4.Item1;
                    A = result4.Item2;
                    A_data = result4.Item3;
                    para = result4.Item4;
                    env = result4.Item5;
                }
                else if ((Enumerable.SequenceEqual(innerForwardNode.attribute.node_type, new List<string>() {"process node", "container node"}) && Enumerable.SequenceEqual(innerForwardNode.attribute.content_type, new List<string>() {"algorithm content"})) || (Enumerable.SequenceEqual(innerForwardNode.attribute.node_type, new List<string>() {"process node", "container node"}) && Enumerable.SequenceEqual(innerForwardNode.attribute.content_type, new List<string>() {"model content"})))
                {
                    var result5 = Executer.ExecuteBranchEntity(innerForwardNode, A, A_data, para, env);
                    innerForwardNode = result5.Item1;
                    A = result5.Item2;
                    A_data = result5.Item3;
                    para = result5.Item4;
                    env = result5.Item5;
                }
                else if (innerForwardNode.attribute.entity_name.Equals("node_START"))
                {
                    var innerForwardProcessState = new ProcessState() {process_state = "has processed"};
                    innerForwardNode.attribute.other["process_state"] = innerForwardProcessState;
                }
                else if (innerForwardNode.attribute.entity_name.Equals("node_END"))
                {
                    var innerForwardProcessState = new ProcessState() {process_state = "has processed"};
                    innerForwardNode.attribute.other["process_state"] = innerForwardProcessState;
                }

                var conditions = new List<bool>();
                foreach (var arrow in innerForwardNode.process)
                {
                    var condition = EvaluateBoolean(arrow["condition"]);
                    Logging.Debug("        条件【" + arrow["condition"] + "】是 " + condition);
                    conditions.Add(condition);
                }

                var selectedArrow = innerForwardNode.process[conditions.IndexOf(true)];
                innerForwardNode = selectedArrow["direction"];
                var selectedArrowProcessState = new ProcessState() {process_state = "has processed"};
                selectedArrow.attribute.other["process_state"] = selectedArrowProcessState;
            }

            return new Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>>(node, A, A_data, para, env);
        }

        return new Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>>(node, A, A_data, para, env);
    }

    private static bool EvaluateBoolean(Agents node)
    {
        var nodeType = node.attribute.node_type;
        var nodeContent = node.attribute.content_type;
        var nodeValue = node.content.attribute.entity_name;
        var nodeOther = node.attribute.other;

        if (Enumerable.SequenceEqual(nodeType, new List<string>() {"content node"}) && Enumerable.SequenceEqual(nodeContent, new List<string>() {"boolean content"}))
        {
            return nodeValue.ToLower().Equals("true");
        }
        else if (Enumerable.SequenceEqual(nodeType, new List<string>() {"content node"}) && Enumerable.SequenceEqual(nodeContent, new List<string>() {"process content"}))
        {
            var processState = (ProcessState) nodeOther["process_state"];
            return processState.process_state.ToLower().Equals("has processed");
        }
        else if (Enumerable.SequenceEqual(nodeType, new List<string>() {"operator node"}) && Enumerable.SequenceEqual(nodeContent, new List<string>() {"logical operator content"}))
        {
            var operands = node.process.Select(p => EvaluateBoolean(p["operand"])).ToList();
            var op = nodeValue.ToLower();

            switch (op)
            {
                case "and":
                    return operands.All(x => x);
                case "or":
                    return operands.Any(x => x);
                case "not":
                    return !operands[0];
                default:
                    return false;
            }
        }
        else
        {
            return false;
        }
    }
}

public class Collector
{
    public static Tuple<AgentDataCollection, Dictionary<string, object>> Collect(Agent A, AgentDataCollection A_data, Dictionary<string, object> env)
    {
        foreach (var key in A_data.data.Keys.ToList())
        {
            var data = A_data.data[key];
            var processState = (Processor.ProcessState) data.other["process_state"];

            if (processState.process_state.Equals("has processed"))
            {
                var value = data.content.attribute.entity_name;
                env[key] = value;
            }
        }

        return new Tuple<AgentDataCollection, Dictionary<string, object>>(A_data, env);
    }
}

public class Executer
{
    public static Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>> ExecuteTerminalEntity(Agents node, Agent A, AgentDataCollection A_data, Dictionary<string, object> para, Dictionary<string, object> env, Agents sourceNode)
    {
        var result = node.content.Execute(A, A_data, para, env);
        A = result.Item1;
        A_data = result.Item2;
        para = result.Item3;
        env = result.Item4;

        var processState = new Processor.ProcessState() {process_state = "has processed"};
        node.attribute.other["process_state"] = processState;

        return new Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>>(sourceNode, A, A_data, para, env);
    }

    public static Tuple<Agents, Agent, AgentDataCollection, Dictionary<string, object>, Dictionary<string, object>> ExecuteBranchEntity(Agents node, Agent A, AgentDataCollection A_data, Dictionary<string, object> para, Dictionary<string, object> env)
    {
        var result = Processor.Process(node, A, A_data, para, env);
        node = result.Item1;
        A = result.Item2;
        A_data = result.Item3;
        para = result