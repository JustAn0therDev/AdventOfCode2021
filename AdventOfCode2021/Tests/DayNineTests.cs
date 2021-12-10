using AdventOfCode2021;
using Xunit;

namespace Tests
{
	public class DayNineTests 
	{
		private readonly AbstractDay _dayNine;

		public DayNineTests() => _dayNine = new DayNine();

		[Fact]
		public void PartOne() => Assert.Equal(478, _dayNine.PartOne());

		[Fact]
		public void PartTwo() => Assert.Equal(1327014, _dayNine.PartTwo());
	}	
}