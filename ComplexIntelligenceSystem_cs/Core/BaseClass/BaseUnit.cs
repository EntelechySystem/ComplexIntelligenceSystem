using System.Diagnostics;
namespace EntelechySystem.ComplexIntelligenceSystem.BaseClass;

class BaseUnit : BaseThing
{
     protected static string TypeName { get; set; } = "base Unit type";
     protected string Head { get; set; } = "base Unit head";
     protected string Body { get; set; } = "base Unit body";

     protected BaseUnit()
     {
          UidString = Id.ToString();
          Debug.WriteLine(TypeName + ": " + UidString);
     }
}