namespace LunchBreakManager.Views;

/// <summary>
/// Views are units in CLI with specific text prompts and functions.
/// Views are presented to the user one at a time.
/// </summary>
public abstract class BaseView
{
  public abstract BaseView? Run();
  protected abstract void Prompt();
}
