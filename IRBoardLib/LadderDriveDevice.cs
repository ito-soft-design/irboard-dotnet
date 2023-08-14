namespace IRBoardLib;
using System.Text.RegularExpressions;

public class LadderDriveDevice {

  public LadderDriveDevice(string name) {
    var pattern = "^(X|Y|M|D|L|H|SC|SD|CC|CS|C|TC|TS|T)([0-9a-f]+)$";
    var matches = Regex.Matches(name, pattern, RegexOptions.IgnoreCase);
    if (matches.Count != 0) {
      var match = matches[0];
      Prefix = match.Groups[1].Value.ToUpper();
      switch (Prefix) {
        case "X":
        case "Y":
          try {
            Number = int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
            if (Number < 1024) {
              IsAvailable = true;
            }
          } catch {}
          break;
        case "C":
        case "CC":
        case "CS":
        case "T":
        case "TC":
        case "TS":
          try {
            Number = int.Parse(match.Groups[2].Value);
            if (Number < 256) {
              IsAvailable = true;
            }
          } catch {}
          break;
        default:
          try {
            Number = int.Parse(match.Groups[2].Value);
            if (Number < 1024) {
              IsAvailable = true;
            }
          } catch {}
          break;
      }
    }
  }
  public string Prefix { get; private set; } = "";

  public int Number { get; private set; } = 0;

  public bool IsAvailable { get; private set; } = false;

  public string Name {
    get {
      switch (Prefix) {
        case "X":
        case "Y":
          return $"{Prefix}{Number.ToString("X")}";
        default:
          return $"{Prefix}{Number}";
      }
    }
  }

}
