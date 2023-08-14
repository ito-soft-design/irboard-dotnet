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

    [TestMethod]
    public void Y_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("Y0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("Y9").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("YA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("YF").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("YG").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("Y10").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("Y3FF").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("Y400").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("y3ff").IsAvailable);
    }

    [TestMethod]
    public void M_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("M0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("M9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("MA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("M1023").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("M1024").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("m1023").IsAvailable);
    }

    [TestMethod]
    public void D_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("D0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("D9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("DA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("D1023").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("D1024").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("d1023").IsAvailable);
    }

    [TestMethod]
    public void L_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("L0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("L9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("LA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("L1023").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("L1024").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("l1023").IsAvailable);
    }

    [TestMethod]
    public void SC_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("SC0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("SC9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("SCA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("SC1023").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("SC1024").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("sc1023").IsAvailable);
    }

    [TestMethod]
    public void SD_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("SD0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("SD9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("SDA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("SD1023").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("SD1024").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("sd1023").IsAvailable);
    }

    [TestMethod]
    public void C_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("C0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("C9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("CA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("C255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("C256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("c255").IsAvailable);
    }

    [TestMethod]
    public void CC_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("CC0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("CC9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("CCA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("CC255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("CC256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("cc255").IsAvailable);
    }

    [TestMethod]
    public void CS_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("CS0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("CS9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("CSA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("CS255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("CS256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("cs255").IsAvailable);
    }

    [TestMethod]
    public void T_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("T0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("T9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("TA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("T255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("T256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("t255").IsAvailable);
    }

    [TestMethod]
    public void TC_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("TC0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("TC9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("TCA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("TC255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("TC256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("tc255").IsAvailable);
    }

    [TestMethod]
    public void TS_Available()
    {
      Assert.IsTrue(new LadderDriveDevice("TS0").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("TS9").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("TSA").IsAvailable);
      Assert.IsTrue(new LadderDriveDevice("TS255").IsAvailable);
      Assert.IsFalse(new LadderDriveDevice("TS256").IsAvailable);

      Assert.IsTrue(new LadderDriveDevice("ts255").IsAvailable);
    }

    [TestMethod]
    public void X_Name()
    {
      Assert.AreEqual("XA", new LadderDriveDevice("XA").Name);
      Assert.AreEqual("XA", new LadderDriveDevice("X0A").Name);
      Assert.AreEqual("XA", new LadderDriveDevice("X00A").Name);
    }

    [TestMethod]
    public void D_Name()
    {
      Assert.AreEqual("D123", new LadderDriveDevice("D123").Name);
      Assert.AreEqual("D123", new LadderDriveDevice("D0123").Name);
      Assert.AreEqual("D123", new LadderDriveDevice("D0123").Name);
    }


}

 