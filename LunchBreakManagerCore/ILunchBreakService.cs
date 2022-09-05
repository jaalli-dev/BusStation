namespace LunchBreakManagerCore;

public interface ILunchBreakService
{
  /// <summary>
  /// Find all time intervals when the number of employees having a break is the greatest.
  /// It is guaranteed that no pairs of intervals are overlapping.
  /// </summary>
  ISet<LBTimeInterval> BusiestTimeIntervals(LBTimeInterval[] timeIntervals);
  
  /// <summary>
  /// Find the greatest number of employees having a break for the given dataset.
  /// </summary>
  int MaxDriversHavingBreak(LBTimeInterval[] timeIntervals);
}
