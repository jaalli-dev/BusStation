using LunchBreakManager.Views;

namespace LunchBreakManager;

public class App
{
  private readonly Context _context = new ();
  private BaseView? _currentView;

  public App()
  {
    _currentView = _context.AppView;
  }

  public void Run()
  {
    Console.WriteLine("Lunch Break Manager");
    while (_currentView != null)
      _currentView = _currentView.Run();
    
    Console.WriteLine("Bye");
  }

  /// <summary>
  /// Primitive argument parsing for providing optional data file.
  /// </summary>
  /// <param name="args">CLI arguments</param>
  /// <returns>this</returns>
  public App Init(string[] args)
  {
    Console.WriteLine(string.Join("\n", args));
    if (args.Length > 1 && args[0] == "-filename")
      _context.AppStateService.AddIntervals(_context.InputReader.ReadInputFile(args[1]));
    return this;
  }
}
