namespace IRBoardLib;

public class IRBoard
{
  public ushort PortNo = 5555;

  public bool IsRunning {
    get { return false; }
  }

  public void Run() {

  }

  public void dStop() {

  }

  public int IntValue(string device) {
    return 0;
  }

  public bool BoolValue(string device) {
    return false;
  }

}
