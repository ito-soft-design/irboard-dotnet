namespace IRBoardLibTest;

using IRBoardLib;

[TestClass]
public class LadderDriveDeviceTest
{

    [TestMethod]
    public void X_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("X0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("X9").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("XA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("XF").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("XG").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("X10").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("X3FF").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("X400").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("x3ff").IsAvailable);
    }


}

 