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
            if (input == "quit")
            {
                irboard.Stop();
                break;
            }
            var a = input.Split(" ");
            if (a.Length == 2)
            {
                // set
                var lawVal = a[1];
                var a2 = a[0].Split(".");
                var d = a2[0];
                if (a2.Length == 2)
                {
                    var t = a2[1];
                    switch (t)
                    {
                        case "u":
                            try
                            {
                                var val = Int32.Parse(lawVal);
                                irboard.SetInt32ValueTo(val, d);
                            }
                            catch { }
                            break;
                        case "d":
                            try
                            {
                                var val = Int32.Parse(lawVal);
                                irboard.SetInt32ValueTo(val, d);
                            }
                            catch { }
                            break;
                        case "ud":
                            try
                            {
                                var val = UInt32.Parse(lawVal);
                                irboard.SetUInt32ValueTo(val, d);
                            }
                            catch { }
                            break;
                        case "f":
                            try
                            {
                                var val = float.Parse(lawVal);
                                irboard.SetFloatValueTo(val, d);
                            }
                            catch { }
                            break;
                        case "s":
                            irboard.SetStringValueTo(lawVal, d);
                            break;
                        default:
                            try
                            {
                                var val = UInt16.Parse(lawVal);
                                irboard.SetUInt16ValueTo(val, d);
                            }
                            catch { }
                            break;
                    }
                }
                else
                {
                    try
                    {
                        var val = UInt16.Parse(lawVal);
                        irboard.SetUInt16ValueTo(val, d);
                    }
                    catch { }
                }
            }
            else
            {
                // get
                var a2 = a[0].Split(".");
                var d = a2[0];
                if (a2.Length == 2)
                {
                    var t = a2[1];
                    switch (t)
                    {
                        case "u":
                            Console.WriteLine($"{d}: {irboard.UInt16ValueOf(d)}");
                            break;
                        case "d":
                            Console.WriteLine($"{d}: {irboard.Int32ValueOf(d)}");
                            break;
                        case "ud":
                            Console.WriteLine($"{d}: {irboard.UInt32ValueOf(d)}");
                            break;
                        case "f":
                            Console.WriteLine($"{d}: {irboard.FloatValueOf(d)}");
                            break;
                        case "s":
                            Console.WriteLine($"{d}: {irboard.StringValueOf(d)}");
                            break;
                        default:
                            Console.WriteLine($"{d}: {irboard.Int16ValueOf(d)}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"{d}: {irboard.Int16ValueOf(d)}");
                }
            }
        } while (true);
        return;

        void PrintUses(IRBoard irboard)
        {
            Console.Clear();
            Console.WriteLine(
                $"Listening on {irboard.IPv4Addresses[0]} : {irboard.PortNo}"
            );
            Console.WriteLine(
@"Create an irBoard project with LadderDrive in the Iot group.
Set the above IP address and port no to it.

commands:
    Read: Enter device name. Usually it return value as Int16.
              e.g., 'm0' or 'd0'
          And you can spcify data type after device,
              .u: UInt16, .d: Int32, .ud: UInt32,
              .f: Float, .s: string
              e.g., 'dm0.s' or 'dm0.f' or 'dm0.s'

    Write: Enter device name and value after that.
              . e.g., 'm0 1' or 'd0 123'
          And you can spcify data type after device,
              .s: Int16, .u: UInt16, .d: Int32, .ud: UInt32,
              .f: Float, .s: string
              e.g., dm0.s or dm0.f or dm0.s
              
    Quit: Enter 'quit'
"
            );

        }

    }
}