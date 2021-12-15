using AdventOfCode2021;
using Xunit;

namespace Tests;

public class DayThirteenTests
{
    private readonly AbstractDay _dayThirteen;

    public DayThirteenTests() => _dayThirteen = new DayThirteen();

    [Fact]
    public void PartOne() => Assert.Equal(775, _dayThirteen.PartOne());

    [Fact]
    // There is actually no way to test this, so I'm testing the points in the final fold.
    public void PartTwo() => Assert.Equal(102, _dayThirteen.PartTwo());
}