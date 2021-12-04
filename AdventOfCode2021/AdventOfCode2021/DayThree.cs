using System;
using System.Linq;

namespace AdventOfCode2021
{
    public class DayThree : AbstractDay
    {
        private readonly string DayThreePartOneInputPath = "inputs\\daythree_partone.txt"; 
        private readonly string DayThreePartTwoInputPath = "inputs\\daythree_parttwo.txt"; 
        
        public override int PartOne()
        {
            string gammaRateBits = string.Empty;
            string epsilonRateBits = string.Empty;

            string[] input = GetInput(DayThreePartOneInputPath);

            const int lineSize = 12;

            for (int i = 0; i < lineSize; i++)
            {
                int oneOccurrences = 0;
                int zeroOccurrences = 0;
                
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j][i] == '0')
                    {
                        zeroOccurrences++;
                    }
                    else
                    {
                        oneOccurrences++;
                    }
                }

                gammaRateBits += oneOccurrences > zeroOccurrences ? '1' : '0';
                epsilonRateBits += oneOccurrences > zeroOccurrences ? '0' : '1';
            }
            
            return Convert.ToInt32(gammaRateBits, 2) * Convert.ToInt32(epsilonRateBits, 2);
        }

        public override int PartTwo()
        {
            return 0;
        }
    }
}