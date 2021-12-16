using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayFourteenTests
    {
        private readonly AbstractDay _dayFourteen;

        public DayFourteenTests() => _dayFourteen = new DayFourteen();

        [Fact]
        public void PartOne() => Assert.Equal(2010, _dayFourteen.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(2437698971143, _dayFourteen.PartTwo());
    }
}
