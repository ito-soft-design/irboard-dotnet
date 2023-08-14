namespace IRBoardLibTest;

using IRBoardLib;

[TestClass]
public class IRBoardTest
{
    [TestMethod]
    public void PortNo_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(5555, irboard.PortNo);
    }

    [TestMethod]
    public void PortNo_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.PortNo = 12345;
        Assert.AreEqual(12345, irboard.PortNo);
    }
}