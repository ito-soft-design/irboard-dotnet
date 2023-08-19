using IRBoardLib;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        IRBoard irboard = new IRBoard();
        PrintUses(irboard);
        irboard.Run();

        do
        {
            Console.Write("$ ");
            string? input = Console.ReadLine();
            if (input == "quit") {
              irboard.Stop();
              break;
            }
        } while (true);
        return;

        void PrintUses(IRBoard irboard) {
            Console.Clear();
            Console.WriteLine(
                $"Listening on {irboard.IPv4Addresses[0]} : {irboard.PortNo}"
            );
            Console.WriteLine(
@"Create an irBoard project with LadderDrive in the Iot group.
Set the above IP address and port no to it.

If you want to quit, input 'quit' and press the 'return' key.
"
            );

        }

    }
}