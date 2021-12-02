using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayTwoTests
    {
        private readonly AbstractDay _dayTwo;

        public DayTwoTests()
        {
            _dayTwo = new DayTwo();
        }
        
        [Fact]
        public void PartOne() => Assert.Equal(1648020, _dayTwo.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(1759818555, _dayTwo.PartTwo());
    }
}