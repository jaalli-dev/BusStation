using LunchBreakManager.Views;
using LunchBreakManagerCore;

namespace LunchBreakManager;

/// <summary>
/// Primitive dependency management system.
/// </summary>
public class Context
{
  public AppView AppView { get; }
  public FileInputView FileInputView { get; }
  public DataInputView DataInputView { get; }
  public IAppStateService AppStateService { get; } = new AppStateService();
  public ILunchBreakService LunchBreakService { get; } = new LunchBreakService();
  public ILBInputReader InputReader { get; } = new LBInputReader();

  public Context()
  {
    AppView = new ();
    FileInputView = new ();
    DataInputView = new ();
    
    AppView.Inject(this);
    FileInputView.Inject(this);
    DataInputView.Inject(this);
  }
}
