using System.Diagnostics;

namespace EntelechySystem.ComplexIntelligenceSystem.Core.BaseClass;

public class BaseDevice : BaseThing
{
    new string UidString { get; set; }
    new string TypeName { get; set; } = "base Device type";
    string Head { get; set; } = "base Device head";
    string Body { get; set; } = "base Device body";
    
    public BaseDevice()
    {
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }
}