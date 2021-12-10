using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayEightTests
    {
        private readonly AbstractDay _dayEight;

        public DayEightTests() => _dayEight = new DayEight();

        [Fact]
        public void PartOne() => Assert.Equal(352, _dayEight.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(936117, _dayEight.PartTwo());
    }
}