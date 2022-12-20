namespace CIS.Core.Base;

class BaseContent : BaseObject
{
    // 内容对象
    public static Guid Uid { get; set; } = Guid.NewGuid();
    public string UidString { get; set; } = Uid.ToString();
    public string TypeName { get; set; } = "base content type";
    public string Head { get; set; } = "base content head";
    public string Body { get; set; } = "base content body";

    public static Guid SetUuid()
    {
        Uid = Guid.NewGuid();
        return Uid;
    }

    public void SetContentBody(string body)
    {
        Body = body;
    }

    public void SetContentHead(string head)
    {
        Head = head;
    }
}