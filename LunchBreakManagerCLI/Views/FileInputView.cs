using LunchBreakManagerCore;

namespace LunchBreakManager.Views;

public class FileInputView : BaseView
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
    var fileName = (Console.ReadLine() ?? "").Trim().ToUpper();
    try
    {
      var data = _inputReader.ReadInputFile(fileName);
      Console.Write("Command:\n>");
      var commandStr = (Console.ReadLine() ?? "").Trim().ToUpper();
      if (commandStr == "R")
        _appStateService.Clear();
      _appStateService.AddIntervals(data);
      Console.WriteLine("Success");
    }
    catch (Exception)
    {
      Console.WriteLine("Exception");
    }

    return _appView;
  }

  protected override void Prompt()
  {
    Console.Write(
      "\nMain > File reader\n" +
      "================================\n" +
      "Commands:\n" +
      "R - Replace loaded entries\n" +
      "Anything else - append to loaded entries\n\n" +
      "Data source file name:\n" +
      ">"
    );
  }
}
