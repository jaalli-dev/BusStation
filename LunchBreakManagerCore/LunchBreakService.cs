using System.Diagnostics.Contracts;

namespace LunchBreakManagerCore;

public class LunchBreakService : ILunchBreakService
{
  [Pure]
  public ISet<LBTimeInterval> BusiestTimeIntervals(LBTimeInterval[] timeIntervals)
  {
    var statistics = Statistics(timeIntervals);
    var timeline = statistics.Keys.ToArray();
    Array.Sort(timeline);
    
    return BusiestTimeIntervals(timeline, statistics);
  }

  [Pure]
  public int MaxDriversHavingBreak(LBTimeInterval[] timeIntervals)
  {
    var statistics = Statistics(timeIntervals);
    var timeline = statistics.Keys.ToArray();
    Array.Sort(timeline);
    
    return MaxDriversHavingBreak(timeline, statistics);
  }

  /// <summary>
  /// Algorithm.
  /// Every time point is associated with a number of employees starting a break at that moment.
  /// The number is negative if more employees are ending a break than starting one at that moment.
  /// </summary>
  private static Dictionary<DateTime, int> Statistics(LBTimeInterval[] timeIntervals)
  {
    var statistics = new Dictionary<DateTime, int>();
    foreach (var timeInterval0 in timeIntervals)
    {
      var timeInterval = new LBTimeInterval(timeInterval0.Start, timeInterval0.End.AddMinutes(1));
      var delta = statistics.GetValueOrDefault(timeInterval.Start, 0);
      statistics[timeInterval.Start] = delta + 1;

      delta = statistics.GetValueOrDefault(timeInterval.End, 0);
      statistics[timeInterval.End] = delta - 1;
    }

    return statistics;
  }

  /// <summary>
  /// Algorithm.
  /// </summary>
  private static int MaxDriversHavingBreak(DateTime[] timeline, Dictionary<DateTime, int> statistics)
  {
    var maxDrivers = 0;
    var currentDrivers = 0;
    foreach (var timePoint in timeline)
    {
      currentDrivers += statistics[timePoint];
      if (currentDrivers > maxDrivers)
        maxDrivers = currentDrivers;
    }

    return maxDrivers;
  }

  /// <summary>
  /// Algorithm.
  /// </summary>
  private static ISet<LBTimeInterval> BusiestTimeIntervals(DateTime[] timeline, Dictionary<DateTime, int> statistics)
  {
    var maxDriversHavingBreak = MaxDriversHavingBreak(timeline, statistics);

    var busiestIntervals = new HashSet<LBTimeInterval>();
    var currentDriversHavingBreak = 0;
    var busiestIntervalStart = new DateTime();
    var wasLastIntervalBusiest = false;
    foreach (var timePoint in timeline)
    {
      currentDriversHavingBreak += statistics[timePoint];

      if (currentDriversHavingBreak == maxDriversHavingBreak && !wasLastIntervalBusiest)
        busiestIntervalStart = timePoint;
      else if (currentDriversHavingBreak != maxDriversHavingBreak && wasLastIntervalBusiest)
        busiestIntervals.Add(new LBTimeInterval(busiestIntervalStart, timePoint.AddMinutes(-1)));
      
      wasLastIntervalBusiest = currentDriversHavingBreak == maxDriversHavingBreak;
    }

    if (currentDriversHavingBreak != maxDriversHavingBreak && wasLastIntervalBusiest)
    {
      var lastTimePoint = timeline[timeline.Length - 1];
      busiestIntervals.Add(new LBTimeInterval(busiestIntervalStart, lastTimePoint.AddMinutes(-1)));
    }

    return busiestIntervals;
  }
}
