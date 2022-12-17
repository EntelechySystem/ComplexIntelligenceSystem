namespace CIS_TestProject;
using CIS;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Machine machine = new Machine();
        Assert.AreEqual("这是一个机。", machine.print());
    }
}
