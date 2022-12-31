using System.Runtime.Serialization;
using EntelechySystem.ComplexIntelligenceSystem.BaseClass;

namespace EntelechySystem.ComplexIntelligenceSystem;

using System;
using System.ComponentModel;

[DataContract]
public class ReadUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "read unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "read unit content head",
        Body = "read unit content body"
    };

    [DataMember]
    public Content FeedbackSign { get; set; } = new Content
    {
        TypeName = "feedback sign type",
        Head = "read unit feedback sign content head",
        Body = "read unit feedback sign content body"
    };

    public ReadUnit()
    {
        FeedbackSign.Uid = Content.SetUuid();
    }

    public Tuple<Content, Content> ReadContent(Content content)
    {
        FeedbackSign = new Content
        {
            TypeName = "read feedback sign type",
            Head = "",
            Body = "read"
        };
        return Tuple.Create(content, FeedbackSign);
    }
}


public class WriteUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "write unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "write unit content head",
        Body = "write unit content body"
    };

    [DataMember]
    public Content FeedbackSign { get; set; } = new Content
    {
        TypeName = "feedback sign type",
        Head = "write unit feedback sign content head",
        Body = "write unit feedback sign content body"
    };

    public Tuple<Content, Content> WriteContent(Content content)
    {
        FeedbackSign = new Content
        {
            TypeName = "write feedback sign type",
            Head = "",
            Body = "wrote"
        };
        Content = content;
        return Tuple.Create(content, FeedbackSign);
    }
}


[DataContract]
public class ReceiverUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "receiver unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "receiver unit content head",
        Body = "receiver unit content body"
    };

    public Tuple<Content, Content> ReceiveContent(Content content)
    {
        // TODO: 对接管线

        var feedbackSign = new Content
        {
            TypeName = "feedback sign type",
            Head = "",
            Body = "received"
        };
        Content = content;
        return Tuple.Create(content, feedbackSign);
    }
}



using System;
using System.ComponentModel;

[DataContract]
public class SenderUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "sender unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "sender unit content head",
        Body = "sender unit content body"
    };

    [DataMember]
    public Content FeedbackSign { get; set; } = new Content
    {
        TypeName = "feedback sign type",
        Head = "sender unit feedback sign content head",
        Body = "sender unit feedback sign content body"
    };

    public Tuple<Content, Content> SendContent(Content content)
    {
        // TODO: 对接管线

        FeedbackSign = new Content
        {
            TypeName = "send feedback sign type",
            Head = "",
            Body = "sent"
        };
        Content = content;
        return Tuple.Create(content, FeedbackSign);
    }
}


using System;
using System.ComponentModel;

[DataContract]
public class ConnectUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "connect unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "connect unit content head",
        Body = "connect unit content body"
    };

    [DataMember]
    public Content FeedbackSign { get; set; } = new Content
    {
        TypeName = "feedback sign type",
        Head = "connect unit feedback sign content head",
        Body = "connect unit feedback sign content body"
    };

    [DataMember]
    public Tuple<float, float> IndexPos { get; set; } = Tuple.Create(0f, 0f);

    public Tuple<Content, Content> ConnectToUnit(Content content)
    {
        // TODO: 对接管线

        FeedbackSign = new Content
        {
            TypeName = "connect feedback sign type",
            Head = "",
            Body = "connected"
        };
        Content = content;
        return Tuple.Create(content, FeedbackSign);
    }
}



using System;
using System.ComponentModel;

[DataContract]
public class CanvasUnit : BaseUnit
{
    [DataMember]
    public string TypeName { get; set; } = "canvas unit type";

    [DataMember]
    public Content Content { get; set; } = new Content
    {
        TypeName = "content type",
        Head = "canvas unit content head",
        Body = "canvas unit content body"
    };

    [DataMember]
    public Content FeedbackSign { get; set; } = new Content
    {
        TypeName = "feedback sign type",
        Head = "canvas unit feedback sign content head",
        Body = "canvas unit feedback sign content body"
    };

    [DataMember]
    public Tuple<float, float, float> IndexPos { get; set; } = (0.0f, 0.0f, 0.0f);

    public Content ShowColorContent()
    {
        FeedbackSign = new Content
        {
            TypeName = "connect feedback sign type",
            Head = "",
            Body = "showed"
        };
        return FeedbackSign;
    }
}
