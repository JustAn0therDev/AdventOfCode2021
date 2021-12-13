using AdventOfCode2021;
using Xunit;

namespace Tests;

public class DayTwelveTests
{
    private readonly AbstractDay _dayTwelve;

    public DayTwelveTests() => _dayTwelve = new DayTwelve();
    
    [Fact]
    public void PartOne() => Assert.Equal(4304, _dayTwelve.PartOne());
    
    [Fact]
    public void PartTwo() => Assert.Equal(118242, _dayTwelve.PartTwo());
}