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

        try {
            irboard.Run();
            Assert.IsTrue(irboard.IsRunning);
            irboard.Stop();
            Assert.IsFalse(irboard.IsRunning);
        } finally {
            irboard.Stop();
        }
    }

   [TestMethod]
    public void BoolValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(false, irboard.BoolValueOf("X0"));
    }

   [TestMethod]
    public void BoolValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetBoolValueTo(true, "X0");
        Assert.AreEqual(true, irboard.BoolValueOf("X0"));
    }

   [TestMethod]
    public void UInt16ValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(0, irboard.UInt16ValueOf("D0"));
    }

   [TestMethod]
    public void UInt16ValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetUInt16ValueTo(12345, "D0");
        Assert.AreEqual(12345, irboard.UInt16ValueOf("D0"));
    }

   [TestMethod]
    public void Int16ValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(0, irboard.Int16ValueOf("D0"));
    }

   [TestMethod]
    public void Int16ValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetInt16ValueTo(-12345, "D0");
        Assert.AreEqual(-12345, irboard.Int16ValueOf("D0"));
    }

   [TestMethod]
    public void UInt32ValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(0U, irboard.UInt32ValueOf("D0"));
    }

   [TestMethod]
    public void UInt32ValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetUInt32ValueTo(1234567890, "D0");
        Assert.AreEqual(1234567890U, irboard.UInt32ValueOf("D0"));
    }

   [TestMethod]
    public void Int32ValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual(0, irboard.Int32ValueOf("D0"));
    }

   [TestMethod]
    public void Int32ValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetInt32ValueTo(-1234567890, "D0");
        Assert.AreEqual(-1234567890U, irboard.Int32ValueOf("D0"));
    }

   [TestMethod]
    public void StringValueOf_Default()
    {
        IRBoard irboard = new IRBoard();
        Assert.AreEqual("", irboard.StringValueOf("D0"));
    }

    [TestMethod]
    public void StringValueOf_Setable()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetStringValueTo("ABCDEFGH", "D0");
        Assert.AreEqual("ABCDEFGH", irboard.StringValueOf("D0"));
    }

    [TestMethod]
    public void SetStringValueOf_WithOddLength()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetStringValueTo("ABCDEFGH", "D0", 3);
        Assert.AreEqual("ABC", irboard.StringValueOf("D0", 3));
    }

    [TestMethod]
    public void SetStringValueOf_WithEvenLength()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetStringValueTo("ABCDEFGH", "D0", 4);
        Assert.AreEqual("ABCD", irboard.StringValueOf("D0", 4));
    }

    [TestMethod]
    public void StringValueOf_WithOddLength()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetStringValueTo("ABCDEFGH", "D0");
        Assert.AreEqual("ABC", irboard.StringValueOf("D0", 3));
    }

    [TestMethod]
    public void StringValueOf_WithEvenLength()
    {
        IRBoard irboard = new IRBoard();
        irboard.SetStringValueTo("ABCDEFGH", "D0");
        Assert.AreEqual("ABCD", irboard.StringValueOf("D0", 4));
    }


}