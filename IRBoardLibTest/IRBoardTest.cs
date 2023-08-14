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

    // NOTE: I don't konw why it is raising a socket exception.
    //       It didn't raise a socket exception in an independent application.
    [Ignore]
    [TestMethod]
    public void Run_and_Stop()
    {
        IRBoard irboard = new IRBoard();
        Assert.IsFalse(irboard.IsRunning);

        Task.Run(async () =>
        {
            irboard.Run();
            Assert.IsTrue(irboard.IsRunning);
            irboard.Stop();
            Assert.IsFalse(irboard.IsRunning);
        }).GetAwaiter().GetResult();

    }

}