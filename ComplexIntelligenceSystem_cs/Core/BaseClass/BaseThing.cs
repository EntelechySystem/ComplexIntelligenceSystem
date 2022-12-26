using System.Diagnostics;

namespace EntelechySystem.ComplexIntelligenceSystem.BaseClass;

public abstract class BaseThing
{
    /// <summary>
    /// 基本事物
    /// </summary>

    protected Guid Id { get; set; } = Guid.NewGuid();

    protected string UidString { get; set; }
    protected static string TypeName { get; set; } = "Thing type";
    protected string Head { get; set; } = "base Thing head";
    protected string Body { get; set; } = "base Thing body";

    protected BaseThing()
    {
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }
}