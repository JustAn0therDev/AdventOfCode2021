using AdventOfCode2021;
using Xunit;

namespace Tests;

public class DayElevenTests
{
    private readonly AbstractDay _dayEleven;

    public DayElevenTests() => _dayEleven = new DayEleven();
    
    [Fact]
    public void PartOne() => Assert.Equal(1642, _dayEleven.PartOne());

    [Fact]
    public void PartTwo() => Assert.Equal(320, _dayEleven.PartTwo());
}