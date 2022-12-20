namespace CIS.Core.Base
{
    public class BaseUnit : BaseObject
    {
        public string TypeName { get; set; } = "base unit type";
        public Content Content { get; set; } = new Content(typeName: "base unit type", head: "base unit content head", body: "base unit content body");
    }
}
