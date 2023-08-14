namespace IRBoardLib;

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


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
        _ = HandleClientAsync(client);
    }
  }
  
  private static async Task HandleClientAsync(TcpClient client)
  {
      try
      {
          // クライアントからのデータを受信、送信する処理をここに記述
          // 例えば、NetworkStreamを使用してデータの送受信を行う
          using (NetworkStream stream = client.GetStream())
          {
              byte[] buffer = new byte[1024];
              int bytesRead;

              while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
              {
                  // データを受信し、必要な処理を行う
                  // ここでは単に受信したデータをそのままクライアントに返す例を示します
                  await stream.WriteAsync(buffer, 0, bytesRead);
              }
          }
      }
      catch (Exception ex)
      {
          Console.WriteLine("クライアントとの通信中にエラーが発生しました: " + ex.Message);
      }
      finally
      {
          // クライアントとの通信が終了したら、接続を閉じる
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
