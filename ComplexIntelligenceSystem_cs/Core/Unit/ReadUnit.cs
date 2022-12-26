using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

 class ReadUnit : BaseUnit
{
    public new string TypeName { get; set; } = "read unit type";

    public Content Content { get; set; } = new Content();

    public Content FeedbackSign { get; set; } = new Content();

    public ReadUnit()
    {
        // FeedbackSign.Uid = Content.SetUuid();
    }

    public ReadUnit(string typeName)
    {
        TypeName = typeName;
    }

    public (Content, Content) ReadContent(Content content)
    {
        FeedbackSign = new Content();
        return (content, FeedbackSign);
    }
}
