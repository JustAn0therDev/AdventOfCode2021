using AdventOfCode2021;
using Xunit;

namespace Tests
{
    public class DaySixTests
    {
        private readonly AbstractDay _daySix;

        public DaySixTests() => _daySix = new DaySix();

        [Fact]
        public void PartOne() => Assert.Equal(351092, _daySix.PartOne());

        [Fact]
        public void PartTwo() => Assert.Equal(1595330616005, _daySix.PartTwo());
    }
}