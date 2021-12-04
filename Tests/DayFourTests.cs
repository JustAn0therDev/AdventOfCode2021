using Xunit;
using AdventOfCode2021;

namespace Tests
{
    public class DayFourTests
    {
        private readonly AbstractDay _dayFour;

        public DayFourTests() => _dayFour = new DayFour();

        [Fact]
        public void PartOne() => Assert.Equal(51776, _dayFour.PartOne());
    }
}