namespace LunchBreakManagerCore;

public interface IAppStateService
{
  public IList<LBTimeInterval> Intervals { get; }
  void AddInterval(LBTimeInterval interval);

  void AddIntervals(IList<LBTimeInterval> intervals);

  void RemoveInterval(LBTimeInterval interval);

  void RemoveIntervals(IList<LBTimeInterval> intervals);
  void Clear();
}