using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DaySevenTests
    {
        private readonly AbstractDay _daySeven;

        public DaySevenTests() => _daySeven = new DaySeven();
        
        [Fact]
        public void PartOne() => Assert.Equal(344297, _daySeven.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(97164301, _daySeven.PartTwo());
    }
}