using System.Diagnostics;
using EntelechySystem.ComplexIntelligenceSystem.Core.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem.Core;

public class Content : BaseContent
{
    internal Guid Uid { get; set; } = Guid.NewGuid();
     string UidString { get; set; }
     internal new string TypeName { get; set; } = "Content type";
     internal string Head { get; set; } = "Content head";
     internal string Body { get; set; } = "Content body";

     public Content()
    {
        // TypeName = "base Content type";
        // Head = "Content head";
        // Body = "Content body";
        UidString = Id.ToString();
        Debug.WriteLine(TypeName + ": " + UidString);
    }

     /// <summary>
     /// 生成全球唯一标志符
     /// </summary>
     /// <returns></returns>
     public Guid SetGuid()
     {
         return Guid.NewGuid();
     }
}