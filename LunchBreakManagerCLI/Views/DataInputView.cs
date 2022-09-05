using LunchBreakManagerCore;

namespace LunchBreakManager.Views;

public class DataInputView : BaseView
{
  private IAppStateService _appStateService = null!;
  private ILBInputReader _inputReader = null!;
  private AppView _appView = null!;

  public void Inject(Context context)
  {
    _appStateService = context.AppStateService;
    _inputReader = context.InputReader;
    _appView = context.AppView;
  }
  
  public override BaseView Run()
  {
    Prompt();
    var intervals = new List<LBTimeInterval>();
    while (true)
    {
      Console.Write(">");
      var line = (Console.ReadLine() ?? "").Trim();
      if (!_inputReader.TryParseLine(line, out var interval))
        break;
      intervals.Add(interval);
    }

    _appStateService.AddIntervals(intervals);
    return _appView;
  }

  protected override void Prompt()
  {
    Console.WriteLine(
      "\nMain > Stdin\n" +
      "================================\n" +
      "Enter entries line by line in format:\n" +
      "hh:MMhh:MM\n" +
      "Anything else to proceed\n"
    );
  }
}
