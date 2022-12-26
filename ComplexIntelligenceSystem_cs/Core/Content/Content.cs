using System.Diagnostics;
using System.Runtime.CompilerServices;
using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

public class Content : BaseContent
{
     Guid Uid { get; set; } = Guid.NewGuid();
     string UidString { get; set; }
     new string TypeName { get; set; } = "Content type";
     string Head { get; set; } = "Content head";
     string Body { get; set; } = "Content body";

    public Content()
    {
        // TypeName = "base Content type";
        // Head = "Content head";
        // Body = "Content body";
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }
}