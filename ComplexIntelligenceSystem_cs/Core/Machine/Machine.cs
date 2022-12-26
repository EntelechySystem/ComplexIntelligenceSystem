using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

public class Machine : BaseMachine
{
    public string print()
    {
        string s = "这是一个机。";
        Console.Write(s);
        return s;
    }
}