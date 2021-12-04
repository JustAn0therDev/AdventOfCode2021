namespace AdventOfCode2021
{
    public class DayOne : AbstractDay
    {
        private const string PartOneInputPath = "Inputs\\dayone_partone.txt";
        private const string PartTwoInputPath = "Inputs\\dayone_parttwo.txt";

        /// <summary>
        /// Count the number of times a depth measurement increases from the previous measurement.
        /// </summary>
        public override long PartOne()
        {
            int count = 0;
            string[] parsed = GetInput(PartOneInputPath);
            for (int i = 0; i < parsed.Length; i++)
            {
                string line = parsed[i];
                int parsedLine = int.Parse(line);
                int previous = i == 0 ? int.Parse(line) : int.Parse(parsed[i - 1]);
                if (previous < parsedLine)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Your goal now is to count the number of times the sum of measurements in this sliding window increases from the previous sum.
        /// So, compare A with B, then compare B with C, then C with D, and so on.
        /// Stop when there aren't enough measurements left to create a new three-measurement sum.
        /// </summary>
        public override long PartTwo()
        {
            int count = 0;
            int previousSum = 0;
            string[] parsed = GetInput(PartTwoInputPath);
            for (int i = 0; i <= parsed.Length; i++)
            {
                if (i + 2 <= parsed.Length - 1)
                {
                    int sum = int.Parse(parsed[i]) + int.Parse(parsed[i + 1]) + int.Parse(parsed[i + 2]);
                    if (i != 0 && previousSum < sum)
                        count++;
                    previousSum = sum;
                }
            }
            return count;
        }
    }
}