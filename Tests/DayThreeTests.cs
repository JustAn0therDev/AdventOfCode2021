using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayThreeTests
    {
        private readonly AbstractDay _dayThree;

        public DayThreeTests() => _dayThree = new DayThree();

        [Fact]
        public void PartOne() => Assert.Equal(1082324, _dayThree.PartOne());
    }
}