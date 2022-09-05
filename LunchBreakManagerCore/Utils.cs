namespace LunchBreakManagerCore;

public static class Utils
{
  public static DateTime LBTimePoint(int hour, int minute)
  {
    return new DateTime(1, 1, 1, hour, minute, 0);
  }

  public static LBTimeInterval LBTimeInterval(int startHour, int startMinute, int endHour, int endMinute)
  {
    return new(LBTimePoint(startHour, startMinute), LBTimePoint(endHour, endMinute));
  }
}