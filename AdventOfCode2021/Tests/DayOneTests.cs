using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DayOneTests
    {
        private readonly AbstractDay _dayOne;
        
        public DayOneTests() => _dayOne = new DayOne();
    
        [Fact]
        public void PartOne() => Assert.Equal(1559, _dayOne.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(1600, _dayOne.PartTwo());
    }    
}
