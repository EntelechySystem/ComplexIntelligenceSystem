using EntelechySystem.ComplexIntelligenceSystem;

namespace CIS_TestProject;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Content content = new Content();
        Assert.AreEqual("这是一个内容。", content);
    }
}
