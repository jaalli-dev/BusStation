namespace LunchBreakManagerCore;

/// <summary>
/// Wrap pair of start and end time points.
/// DateTime structs could be replaced with more specific time point type.
/// </summary>
public struct LBTimeInterval : IEquatable<LBTimeInterval>
{
  public DateTime Start { get; }
  public DateTime End { get; }

  public LBTimeInterval(DateTime start, DateTime end)
  {
    Start = start;
    End = end;
  }

  public bool Equals(LBTimeInterval other)
  {
    return Start.Hour == other.Start.Hour && Start.Minute == other.Start.Minute 
      && End.Hour == other.End.Hour && End.Minute == other.End.Minute;
  }

  public override string ToString()
  {
    return $"{Start.Hour}:{Start.Minute}-{End.Hour}:{End.Minute}";
  }
}
