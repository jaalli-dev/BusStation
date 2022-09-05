namespace LunchBreakManagerCore;

public interface ILBInputReader
{
  LBTimeInterval[] ReadInputFile(string filePath);

  bool TryParseLine(string line, out LBTimeInterval interval);
}