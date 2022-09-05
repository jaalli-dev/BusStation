using System;
using Xunit;

namespace LunchBreakManagerCore.Tests.LunchBreakServiceTests;

public class MaxDriversHavingBreakTest
{
  private readonly ILunchBreakService _lunchBreakService = new LunchBreakService();

  [Fact]
  public void CanFindMaxDriversHavingBreakWithEmptyInput()
  {
    var timeIntervals = Array.Empty<LBTimeInterval>();
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);

    Assert.Equal(0, maxDriversHavingBreak);
  }
  
  [Fact]
  public void CanFindMaxDriversHavingBreakWithOneRecord()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 12, 0),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(1, maxDriversHavingBreak);
  }

  [Fact]
  public void CanFindMaxDriversHavingBreakWithOverlappingLunchTimes()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 12, 0),
      Utils.LBTimeInterval(11, 30, 12, 30),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(2, maxDriversHavingBreak);
  }

  [Fact]
  public void CanFindMaxDriversHavingBreakWithNotOverlappingLunchTimes()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(12, 0, 12, 30),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(1, maxDriversHavingBreak);
  }

  [Fact]
  public void CanFindMaxDriversHavingBreakEdgeCase()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(11, 30, 12, 0),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(2, maxDriversHavingBreak);
  }

  [Fact]
  public void CanFindMaxDriversHavingBreakSameInterval()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(11, 0, 11, 30),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(2, maxDriversHavingBreak);
  }

  [Fact]
  public void CanFindMaxDriversHavingBreak()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(10, 30, 11, 35),
      Utils.LBTimeInterval(10, 15, 11, 15),
      Utils.LBTimeInterval(11, 20, 11, 50),
      Utils.LBTimeInterval(10, 35, 11, 40),
      Utils.LBTimeInterval(10, 20, 11, 20),
    };
    
    var maxDriversHavingBreak = _lunchBreakService.MaxDriversHavingBreak(timeIntervals);
    
    Assert.Equal(4, maxDriversHavingBreak);
  }
}
