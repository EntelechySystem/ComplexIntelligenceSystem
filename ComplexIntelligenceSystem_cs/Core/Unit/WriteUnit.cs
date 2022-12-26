using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

class WriteUnit : BaseUnit
{
    public new string TypeName = "write unit type";
    public Content Content = new Content();
    public Content FeedbackSign = new Content();

    public WriteUnit(string typeName)
    {
        TypeName = typeName;
    }

    public (Content, Content) WriteContent(Content content)
    {
        FeedbackSign = new Content();
        Content = content;
        return (Content, FeedbackSign);
    }
}