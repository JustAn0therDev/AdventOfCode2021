using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayFiveTests
    {
        private readonly AbstractDay _dayFive;

        public DayFiveTests() => _dayFive = new DayFive();

        [Fact]
        public void PartOne() => Assert.Equal(6007, _dayFive.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(19349, _dayFive.PartTwo());
    }
}