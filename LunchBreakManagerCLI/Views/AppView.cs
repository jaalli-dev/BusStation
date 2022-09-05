using LunchBreakManagerCore;

namespace LunchBreakManager.Views;

public class AppView : BaseView
{
  private IAppStateService _appStateService = null!;
  private ILunchBreakService _lunchBreakService = null!;

  private FileInputView _fileInputView = null!;
  private DataInputView _dataInputView = null!;

  public void Inject(Context context)
  {
    _appStateService = context.AppStateService;
    _lunchBreakService = context.LunchBreakService;
    _fileInputView = context.FileInputView;
    _dataInputView = context.DataInputView;
  }

  public override BaseView? Run()
  {
    Prompt();
    var commandStr = (Console.ReadLine() ?? "").Trim().ToUpper();
    switch (commandStr)
    {
      case "P":
        PrintIntervals();
        break;
      case "M":
        PrintMaxDriversHavingBreak();
        break;
      case "B":
        PrintBusiestTimeIntervals();
        break;
      case "FILE":
        return _fileInputView;
      case "DATA":
        return _dataInputView;
      case "Q":
        return null;
      default:
        Console.WriteLine("Unknown command");
        break;
    }
    return this;
  }
  
  protected override void Prompt()
  {
    Console.Write(
      "\nMain\n" +
      "================================\n" +
      "P - Print loaded entries\n" +
      "M - Calculate and print maximum number of drivers having a break\n" +
      "B - Calculate and print all time intervals when maximum number of drivers are having a break\n" +
      "FILE - Load entries from a file\n" +
      "DATA - Load entries from stdin\n" +
      "C - Clear loaded entries\n" +
      "Q - Exit gracefully\n\n" +
      ">"
    );
  }

  private void PrintIntervals()
  {
    var intervals = _appStateService.Intervals;
    Console.WriteLine($"Count: {intervals.Count}\n" + string.Join("\n", _appStateService.Intervals));
  }

  private void PrintMaxDriversHavingBreak()
  {
    Console.WriteLine(_lunchBreakService.MaxDriversHavingBreak(_appStateService.Intervals.ToArray()));
  }

  private void PrintBusiestTimeIntervals()
  {
    var intervals = _lunchBreakService.BusiestTimeIntervals(_appStateService.Intervals.ToArray());
    Console.WriteLine($"Count: {intervals.Count}\n" + string.Join("\n", intervals));
  }
}
