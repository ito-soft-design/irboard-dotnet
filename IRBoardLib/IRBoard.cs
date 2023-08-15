namespace IRBoardLib;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public class IRBoard
{
  public ushort PortNo = 5555;

  public bool IsRunning {
    get { return listener != null; }
  }

  private TcpListener? listener = null;

  public async void Run() {
    if (IsRunning) { return; }
  
    IPAddress ipAddress = IPAddress.Any;
    listener = new TcpListener(ipAddress, PortNo);
    listener.Start();

    Console.WriteLine("Launched a server. Waitting a connection from a client...");

    while (true)
    {
        TcpClient client = await listener.AcceptTcpClientAsync();

        Console.WriteLine("Connected with a new client");

        // クライアント接続ごとに処理を非同期で実行
        _ = HandleClientAsync(this, client);
    }
  }


  private object lockObj = "lockObj";
  private Dictionary<LadderDriveDevice, UInt16> deviceDict = new Dictionary<LadderDriveDevice, UInt16>();

  private UInt16 GetValueOfDevice(LadderDriveDevice device) {
    UInt16 val = 0;
    lock(lockObj) {
      if (deviceDict.ContainsKey(device)) {
        val = deviceDict[device];
      }
    }
    return val;
  }

  private void SetValueToDevice(UInt16 value, LadderDriveDevice device) {
    lock(lockObj) {
      deviceDict[device] = value;
    }
  }

  private string RdResponse(string[] elements) {
    if (elements.Length != 2) { return "E1"; }
    var a = elements[1].Split(".");
    var d = new LadderDriveDevice(a[0]);
    if (d.IsAvailable == false) { return "E1"; }
    var format = a.Length >= 2 && a[1].ToUpper() == "H" ? "X" : "";
    return GetValueOfDevice(d).ToString(format);
  }
  
  private string RdsResponse(string[] elements) {
    if (elements.Length != 3) { return "E1"; }

    var a = elements[1].Split(".");
    var d = new LadderDriveDevice(a[0]);
    var c = int.Parse(elements[2]);
    string[] res = new string[c];
    var format = a.Length >= 2 && a[1].ToUpper() == "H" ? "X" : "";

    for (int i = 0; i < c; i++) {
      if (d.IsAvailable == false) { return "E1"; }
      res[i] = GetValueOfDevice(d).ToString(format);
      d = d.NextDevice;
    }
    return string.Join(" ", res);
  }
  
  private string StResponse(string[] elements) {
    if (elements.Length != 2) { return "E1"; }
    var d = new LadderDriveDevice(elements[1]);
    if (d.IsAvailable == false) { return "E1"; }
    SetValueToDevice(1, d);
    return "OK";
  }
  
  private string RsResponse(string[] elements) {
    if (elements.Length != 2) { return "E1"; }
    var d = new LadderDriveDevice(elements[1]);
    if (d.IsAvailable == false) { return "E1"; }
    SetValueToDevice(0, d);
    return "OK";
  }
  
  private string WrResponse(string[] elements) {
    if (elements.Length != 3) { return "E1"; }
    var a = elements[1].Split(".");
    var d = new LadderDriveDevice(a[0]);
    if (d.IsAvailable == false) { return "E1"; }
    if (a.Length >= 2 && a[1].ToUpper() == "H") {
      UInt16 val = UInt16.Parse(elements[2], System.Globalization.NumberStyles.HexNumber);
      SetValueToDevice(val, d);
    } else {
      UInt16 val = UInt16.Parse(elements[2]);
      SetValueToDevice(val, d);
    }
    return "OK";
  }
  
  private string WrsResponse(string[] elements) {
    if (elements.Length < 3) { return "E1"; }
    var a = elements[1].Split(".");
    var d = new LadderDriveDevice(a[0]);
    if (d.IsAvailable == false) { return "E1"; }
    var c = int.Parse(elements[2]);
    if (elements.Length != 3 + c) { return "E1"; }
    var hex = a.Length >= 2 && a[1].ToUpper() == "H";
    for (int i = 0; i < c; i++) {
      if (hex) {
        UInt16 val = UInt16.Parse(elements[3 + i], System.Globalization.NumberStyles.HexNumber);
        SetValueToDevice(val, d);
      } else {
        UInt16 val = UInt16.Parse(elements[3 + i]);
        SetValueToDevice(val, d);
      }
      d = d.NextDevice;
    }
    return "OK";
  }
  
  private static async Task HandleClientAsync(IRBoard board, TcpClient client)
  {
    DateTime connectedAt = DateTime.Now;

    try
    {
      using (NetworkStream stream = client.GetStream())
      {
        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII)) {
          using (StreamWriter writer = new StreamWriter(stream)) {
            while(true) {
              string message = reader.ReadLine();
              if (message != null) {
                connectedAt = DateTime.Now;
                var elements = message.Split(' ');
                var response = "";
                try {
                  switch (elements[0].ToUpper()) {
                    case "RD":
                      response = board.RdResponse(elements);
                      break;
                    case "RDS":
                      response = board.RdsResponse(elements);
                      break;
                    case "ST":
                      response = board.StResponse(elements);
                      break;
                    case "RS":
                      response = board.RsResponse(elements);
                      break;
                    case "WR":
                      response = board.WrResponse(elements);
                      break;
                    case "WRS":
                      response = board.WrsResponse(elements);
                      break;
                    default:
                      response = "E1";
                      break;
                  }
                } catch (ArgumentNullException) {
                  response = "E1";
                } catch (ArgumentException) {
                  response = "E1";
                } catch (FormatException) {
                  response = "E1";
                } catch (OverflowException) {
                  response = "E1";
                }
                writer.Write(response + "\r\n");
                writer.Flush();
              }

              // check timeout
              var now = DateTime.Now;
              if ((now - connectedAt).TotalSeconds > 5) {
                break;
              }

              Thread.Sleep(10);
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("An error was occurred connecting with a client: " + ex.Message);
    }
    finally
    {
      client.Close();
    }
  }

  public void Stop() {
    if (listener == null) { return; }
    listener.Stop();
  }

  public int IntValue(string device) {
    return 0;
  }

  public bool BoolValue(string device) {
    return false;
  }

}
