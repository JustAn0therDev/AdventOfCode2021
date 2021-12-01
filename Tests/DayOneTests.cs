using AdventOfCode2021;
using Xunit;
using AdventOfCode2021.Day_1;

namespace Tests
{
    public class DayOneTests
    {
        private readonly IDay _dayOne;
        
        public DayOneTests() => _dayOne = new DayOne();
    
        [Fact]
        public void PartOne() => Assert.Equal(1559, _dayOne.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(1600, _dayOne.PartTwo());
    }    
}
