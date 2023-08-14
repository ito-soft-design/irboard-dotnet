using IRBoardLib;

class Program
{
    static void Main(string[] args)
    {
        ResetConsole();

        IRBoard irboard = new IRBoard();
        irboard.Run();

        do
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            Console.WriteLine($"Input: {input}");
            if (input == "quit") {
              irboard.Stop();
              break;
            }
        } while (true);
        return;

        // Declare a ResetConsole local method
        void ResetConsole()
        {
            Console.Clear();
            Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}");
        }
    }
}