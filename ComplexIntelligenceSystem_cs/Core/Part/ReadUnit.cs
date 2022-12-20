using CIS.Core.Base;

namespace CIS.Core.Part;

public class ReadUnit : BaseUnit
{
    public string type_name { get; set; } = "read unit type";

    public Content content { get; set; } = new Content(type_name: "content type", head: "read unit content head", body: "read unit content body");

    public Content feedback_sign { get; set; } = new Content(type_name: "feedback sign type", head: "read unit feedback sign content head", body: "read unit feedback sign content body");

    public ReadUnit()
    {
        feedback_sign.uid = Content.SetUuid();
    }

    public (Content, Content) ReadContent(Content content)
    {
        feedback_sign = new Content(type_name: "read feedback sign type", head: "", body: "read");
        return (content, feedback_sign);
    }
}
