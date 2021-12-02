namespace AdventOfCode2021
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
            
            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] lineSplit = inputLines[i].Split(' ');
                string instruction = lineSplit[0];
                int times = int.Parse(lineSplit[1]);

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
        
        /// <summary>
        /// Based on your calculations, the planned course doesn't seem to make any sense. You find the submarine manual and discover that the process is actually slightly more complicated.
        /// In addition to horizontal position and depth, you'll also need to track a third value, aim, which also starts at 0.
        /// The commands also mean something entirely different than you first thought:
        /// "down X" increases your aim by X units.
        /// "up X" decreases your aim by X units.
        /// "forward X" does two things:
        ///  It increases your horizontal position by X units.
        ///  It increases your depth by your aim multiplied by X.
        /// Using this new interpretation of the commands, calculate the horizontal position and depth you would have after following the planned course.
        /// </summary>
        public override int PartTwo()
        {
            Position pos = new();
            string[] inputLines = GetInput(PartTwoInputPath);
            
            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] lineSplit = inputLines[i].Split(' ');
                string instruction = lineSplit[0];
                int times = int.Parse(lineSplit[1]);

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