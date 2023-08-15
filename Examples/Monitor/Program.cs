using IRBoardLib;

class Program
{
    static void Main(string[] args)
    {
        PrintUses();

        IRBoard irboard = new IRBoard();
        irboard.Run();

        do
        {
            string? input = Console.ReadLine();
            Console.WriteLine($"Input: {input}");
            if (input == "quit") {
              irboard.Stop();
              break;
            }
        } while (true);
        return;

        void PrintUses() {
            Console.Clear();
            Console.WriteLine(
@"

Waiting a connection from irBoard. 
If you want to quit; input 'quit' and press the 'return' key.
"
            );

        }

    }
}