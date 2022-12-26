
using System.Diagnostics;

namespace EntelechySystem.ComplexIntelligenceSystem.BaseClass;

public class BaseMachine : BaseThing
{
    new string UidString { get; set; }
    new string TypeName { get; set; } = "base Machine type";
    string Head { get; set; } = "base Machine head";
    string Body { get; set; } = "base Machine body";
    
    public BaseMachine()
    {
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }
}