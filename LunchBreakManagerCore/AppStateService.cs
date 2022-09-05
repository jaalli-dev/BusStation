namespace LunchBreakManagerCore;

public class AppStateService : IAppStateService
{
  public IList<LBTimeInterval> Intervals => new List<LBTimeInterval>(_intervals);
  private readonly IList<LBTimeInterval> _intervals = new List<LBTimeInterval>();

  public void AddInterval(LBTimeInterval interval)
  {
    _intervals.Add(interval);
  }
  
  public void AddIntervals(IList<LBTimeInterval> intervals)
  {
    foreach (var interval in intervals)
      AddInterval(interval);
  }
  
  public void RemoveInterval(LBTimeInterval interval)
  {
    _intervals.Remove(interval);
  }
  
  public void RemoveIntervals(IList<LBTimeInterval> intervals)
  {
    foreach (var interval in intervals)
      RemoveInterval(interval);
  }

  public void Clear()
  {
    _intervals.Clear();
  }
}