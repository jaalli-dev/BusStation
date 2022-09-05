using System;
using System.Linq;
using Xunit;

namespace LunchBreakManagerCore.Tests.LunchBreakServiceTests;

public class BusiestTimeIntervalsTest
{
  private readonly ILunchBreakService _lunchBreakService = new LunchBreakService();

  [Fact]
  public void CanFindBusiestTimeIntervalsWithEmptyInput()
  {
    var timeIntervals = Array.Empty<LBTimeInterval>();
    
    var expected = Array.Empty<LBTimeInterval>().ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }
  
  [Fact]
  public void CanFindBusiestTimeIntervalsWithOneRecord()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 12, 0),
    };
    
    var expected = new []
    {
      Utils.LBTimeInterval(11, 0, 12, 0),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }

  [Fact]
  public void CanFindBusiestTimeIntervalsWithOverlappingLunchTimes()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 12, 0),
      Utils.LBTimeInterval(11, 30, 12, 30),
    };
    
    var expected = new []
    {
      Utils.LBTimeInterval(11, 30, 12, 0),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }

  [Fact]
  public void CanFindBusiestTimeIntervalsWithNotOverlappingLunchTimes()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(12, 0, 12, 30),
    };
    
    var expected = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(12, 0, 12, 30),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }

  [Fact]
  public void CanFindBusiestTimeIntervalsEdgeCase()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(11, 30, 12, 0),
    };

    var expected = new []
    {
      Utils.LBTimeInterval(11, 30, 11, 30),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }

  [Fact]
  public void CanFindBusiestTimeIntervalsSameInterval()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
      Utils.LBTimeInterval(11, 0, 11, 30),
    };

    var expected = new []
    {
      Utils.LBTimeInterval(11, 0, 11, 30),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }

  [Fact]
  public void CanFindBusiestTimeIntervals()
  {
    var timeIntervals = new []
    {
      Utils.LBTimeInterval(10, 30, 11, 35),
      Utils.LBTimeInterval(10, 15, 11, 15),
      Utils.LBTimeInterval(11, 20, 11, 50),
      Utils.LBTimeInterval(10, 35, 11, 40),
      Utils.LBTimeInterval(10, 20, 11, 20),
    };
    
    var expected = new []
    {
      Utils.LBTimeInterval(10, 35, 11, 15),
      Utils.LBTimeInterval(11, 20, 11, 20),
    }.ToHashSet();
    
    var busiestTimeIntervals = _lunchBreakService.BusiestTimeIntervals(timeIntervals);
    
    Assert.Equal(expected, busiestTimeIntervals);
  }
}
