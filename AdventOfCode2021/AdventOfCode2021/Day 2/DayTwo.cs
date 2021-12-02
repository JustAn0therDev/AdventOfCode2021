namespace AdventOfCode2021.Day_2
{
    internal record struct Position
    {
        internal int Depth { get; set; }
        internal int Horizontal { get; set; }
        internal int Aim { get; set; }

        internal int GetPosition() => Horizontal * Depth;
    }
    
    public class DayTwo : AbstractDay
    {
        private const string PartOneInputPath = "Inputs\\daytwo_partone.txt";
        private const string PartTwoInputPath = "Inputs\\daytwo_parttwo.txt";

        /// <summary>
        /// Calculate the horizontal position and depth you would have after following the planned course.
        /// Depth * horizontal
        /// </summary>
        public override int PartOne()
        {
            Position pos = new();
            string[] inputLines = GetInput(PartOneInputPath);
            
            for (var i = 0; i < inputLines.Length; i++)
            {
                string[] lineSplit = inputLines[i].Split(' ');
                string instruction = lineSplit[0];
                var times = int.Parse(lineSplit[1]);

                if (instruction == "forward")
                {
                    pos.Horizontal += times;
                }
                else
                {
                    pos.Depth += instruction == "up" ? -times : times;
                }
            }

            return pos.GetPosition();
        }
        
        public override int PartTwo()
        {
            Position pos = new();
            string[] inputLines = GetInput(PartTwoInputPath);
            
            for (var i = 0; i < inputLines.Length; i++)
            {
                string[] lineSplit = inputLines[i].Split(' ');
                string instruction = lineSplit[0];
                var times = int.Parse(lineSplit[1]);

                if (instruction == "forward")
                {
                    pos.Horizontal += times;
                    pos.Depth += pos.Aim * times;
                }
                else
                {
                    pos.Aim += instruction == "up" ? -times : times;
                }
            }

            return pos.GetPosition();
        }
    }
}