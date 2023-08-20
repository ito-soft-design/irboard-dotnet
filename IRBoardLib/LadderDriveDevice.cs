namespace IRBoardLib;
using System.Text.RegularExpressions;

public class LadderDriveDevice
{

    public LadderDriveDevice(string prefix, int number)
    {
        Prefix = prefix;
        Number = number;
        CheckAvailable();
    }

    public LadderDriveDevice(string name)
    {
        var pattern = "^(X|Y|M|D|L|H|SC|SD|CC|CS|C|TC|TS|T)([0-9a-f]+)$";
        var matches = Regex.Matches(name, pattern, RegexOptions.IgnoreCase);
        if (matches.Count != 0)
        {
            var match = matches[0];
            Prefix = match.Groups[1].Value.ToUpper();
            switch (Prefix)
            {
                case "X":
                case "Y":
                    try
                    {
                        Number = int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
                        CheckAvailable();
                    }
                    catch { return; }
                    break;
                case "C":
                case "CC":
                case "CS":
                case "T":
                case "TC":
                case "TS":
                    try
                    {
                        Number = int.Parse(match.Groups[2].Value);
                        CheckAvailable();
                    }
                    catch { return; }
                    break;
                default:
                    try
                    {
                        Number = int.Parse(match.Groups[2].Value);
                        CheckAvailable();
                    }
                    catch { return; }
                    break;
            }
        }
    }

    private void CheckAvailable()
    {
        switch (Prefix)
        {
            case "X":
            case "Y":
                if (Number < 1024)
                {
                    IsAvailable = true;
                }
                break;
            case "C":
            case "CC":
            case "CS":
            case "T":
            case "TC":
            case "TS":
                if (Number < 256)
                {
                    IsAvailable = true;
                }
                break;
            default:
                if (Number < 1024)
                {
                    IsAvailable = true;
                }
                break;
        }
    }

    public string Prefix { get; private set; } = "";

    public int Number { get; private set; } = 0;

    public bool IsAvailable { get; private set; } = false;

    public bool IsBitDevice
    {
        get
        {
            switch (Prefix)
            {
                case "X":
                case "Y":
                case "M":
                    return true;
                default:
                    return false;
            }
        }
    }

    public string Name
    {
        get
        {
            switch (Prefix)
            {
                case "X":
                case "Y":
                    return $"{Prefix}{Number.ToString("X")}";
                default:
                    return $"{Prefix}{Number}";
            }
        }
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return obj is LadderDriveDevice device && Name == device.Name;
    }

    public LadderDriveDevice PrevDevice
    {
        get
        {
            return new LadderDriveDevice(Prefix, Number - 1);
        }
    }

    public LadderDriveDevice NextDevice
    {
        get
        {
            return new LadderDriveDevice(Prefix, Number + 1);
        }
    }


}
