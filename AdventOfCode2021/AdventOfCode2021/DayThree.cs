using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class DayThree : AbstractDay
    {
        private const string DayThreePartOneInputPath = "inputs\\daythree_partone.txt"; 
        private const string DayThreePartTwoInputPath = "inputs\\daythree_parttwo.txt";
        private const int LineSize = 12;
        
        public override long PartOne()
        {
            string gammaRateBits = string.Empty;
            string epsilonRateBits = string.Empty;

            string[] input = GetInput(DayThreePartOneInputPath);

            for (int i = 0; i < LineSize; i++)
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

        public override long PartTwo()
        {
            string[] input = GetInput(DayThreePartTwoInputPath);

            List<string> filteredForOxygen = new(input); 
            List<string> filteredForCarbonDioxide = new(input);

            for (int i = 0; i < LineSize; i++)
            {
                (int oneOccurrences, int zeroOccurrences) = GetOccurrencesFor(filteredForOxygen, i);

                if (filteredForOxygen.Count > 1)
                {
                    filteredForOxygen = filteredForOxygen.Where(w => oneOccurrences >= zeroOccurrences ? w[i] == '1' : w[i] == '0').ToList();
                }

                (oneOccurrences, zeroOccurrences) = GetOccurrencesFor(filteredForCarbonDioxide, i);

                if (filteredForCarbonDioxide.Count > 1)
                {
                    filteredForCarbonDioxide = filteredForCarbonDioxide.Where(w => oneOccurrences >= zeroOccurrences ? w[i] == '0' : w[i] == '1').ToList();
                }
            }
            
            return Convert.ToInt32(filteredForOxygen[0], 2) * Convert.ToInt32(filteredForCarbonDioxide[0], 2);
        }

        private (int, int) GetOccurrencesFor(IReadOnlyList<string> report, int bitIndex)
        {
            int zero = 0;
            int one = 0;
            for (int i = 0; i < report.Count; i++)
            {
                if (report[i][bitIndex] == '0')
                {
                    zero++;
                }
                else
                {
                    one++;
                }
            }

            return (one, zero);
        }
    }
}
