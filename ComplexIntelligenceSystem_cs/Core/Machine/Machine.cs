
using EntelechySystem.ComplexIntelligenceSystem.Core.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem.Core;

internal class Machine : BaseMachine
{
    public string print()
    {
        string s = "这是一个机。";
        Console.Write(s);
        return s;
    }
}