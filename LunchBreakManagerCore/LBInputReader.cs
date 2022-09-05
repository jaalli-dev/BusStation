using System.Text.RegularExpressions;

namespace LunchBreakManagerCore;

public class LBInputReader : ILBInputReader
{
  private static readonly Regex DefaultPattern = 
    new ("(\\d{2}):(\\d{2})(\\d{2}):(\\d{2})", RegexOptions.Compiled);
  
  public LBTimeInterval[] ReadInputFile(string filePath)
  {
    var lines = File.ReadAllLines(filePath);
    return ParseLines(lines);
  }

  public bool TryParseLine(string line, out LBTimeInterval interval)
  {
    try
    {
      interval = ParseLine(line);
      return true;
    }
    catch (Exception)
    {
      interval = new LBTimeInterval();
      return false;
    }
  }

  static LBTimeInterval[] ParseLines(string[] lines)
  {
    var timeIntervals = new LBTimeInterval[lines.Length];
    for (var i = 0; i < lines.Length; i++)
      timeIntervals[i] = ParseLine(lines[i]);
    
    return timeIntervals;
  }

  static LBTimeInterval ParseLine(string line)
  {
    var match = DefaultPattern.Match(line);
    var startHour = int.Parse(match.Groups[1].Value);
    var startMinute = int.Parse(match.Groups[2].Value);
    var endHour = int.Parse(match.Groups[3].Value);
    var endMinute = int.Parse(match.Groups[4].Value);

    var start = Utils.LBTimePoint(startHour, startMinute);
    var end = Utils.LBTimePoint(endHour, endMinute);

    return new LBTimeInterval(start, end);
  }
}
