using AdventOfCode2021;
using Xunit;

namespace Tests;

public class DayTenTests
{
    private readonly AbstractDay _dayTen;

    public DayTenTests() => _dayTen = new DayTen();

    [Fact]
    public void PartOne() => Assert.Equal(389589, _dayTen.PartOne());
    
    [Fact]
    public void PartTwo() => Assert.Equal(1190420163, _dayTen.PartTwo());
}