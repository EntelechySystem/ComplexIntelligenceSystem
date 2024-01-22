using System.Diagnostics;

namespace EntelechySystem.ComplexIntelligenceSystem.Core.BaseClass;

/// <summary>
/// 基本内容
/// </summary>
public abstract class BaseContent : BaseThing
{
    new Guid Id { get; set; } = Guid.NewGuid();
    new string UidString { get; set; }

    new string TypeName { get; set; } = "base Content type";
    new string Head { get; set; } = "base Content head";
    new string Body { get; set; } = "base Content body";

    protected BaseContent()
    {
        // TypeName = "base Content type";
        // Head = "base Content head";
        // Body = "base Content body";
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }
}