using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class DayEight : AbstractDay
    {
        private const string DayEightInputPath = "Inputs\\dayeight.txt";
        
        private const int SEGMENTS_IN_ONE = 2;
        private const int SEGMENTS_IN_FOUR = 4;
        private const int SEGMENTS_IN_SEVEN = 3;
        private const int SEGMENTS_IN_EIGHT = 7;

        private static readonly int[] ValidSegments = { SEGMENTS_IN_ONE, SEGMENTS_IN_FOUR, SEGMENTS_IN_SEVEN, SEGMENTS_IN_EIGHT };
        
        public override long PartOne()
        {
            long result = 0;

            IEnumerable<string> input = ParseInput();

            foreach (var line in input)
            {
                foreach (var number in line.Split(" "))
                {
                    if (ValidSegments.Contains(number.Length))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public override long PartTwo()
        {
            long result = 0;

            IEnumerable<string[]> input = ParseInputPartTwo();

            foreach (var line in input)
            {
                string[] firstSegment = line[0].Split(' ');
                string[] secondSegment = line[1].Split(' ');

                Dictionary<char, string> segmentToChar = new()
                {
                    ['4'] = string.Empty,
                    ['7'] = string.Empty
                };

                List<string> firstTwoEl = firstSegment.OrderBy(o => o.Length).Take(1..3).ToList();

                segmentToChar['7'] = firstTwoEl[0];
                segmentToChar['4'] = firstTwoEl[1];

                string generatedNumberFromSegments = string.Empty;

                foreach (var number in secondSegment)
                {
                    generatedNumberFromSegments += number.Length switch
                    {
                        SEGMENTS_IN_ONE => "1",
                        SEGMENTS_IN_FOUR => "4",
                        SEGMENTS_IN_SEVEN => "7",
                        SEGMENTS_IN_EIGHT => "8",
                        _ => GetNumberFromCurrentSegments(segmentToChar, number)
                    };
                }
                result += int.Parse(generatedNumberFromSegments);
            }

            return result;
        }

        private static string GetNumberFromCurrentSegments(Dictionary<char, string> segmentToChar, string number)
        {
            if (number.Length == 5)
            {
                if (segmentToChar['7'].All(number.Contains) &&
                    segmentToChar['4'].Any(number.Contains))
                    return "3";
            
                if (segmentToChar['4'].Count(number.Contains) == 2 &&
                    segmentToChar['7'].Count(number.Contains) == 2)
                    return "2";
            
                if (segmentToChar['4'].Count(number.Contains) == 3 &&
                    segmentToChar['7'].Count(number.Contains) == 2)
                    return "5";                
            }
            
            if (segmentToChar['4'].Count(number.Contains) == 3 &&
                segmentToChar['7'].Count(number.Contains) == 2)
                return "6";

            if (segmentToChar['4'].All(number.Contains) && segmentToChar['7'].All(number.Contains))
                return "9";
            
            if (segmentToChar['7'].All(number.Contains) && segmentToChar['4'].Count(number.Contains) == 3)
                return "0";

            return "";
        }

        private static IEnumerable<string> ParseInput()
        {
            string input = File.ReadAllText(DayEightInputPath);
            List<string> lines = input.Split("\r\n").Select(s => string.Join(" ", s.Split("|")[1])).ToList();
            return lines;
        }
        
        private static IEnumerable<string[]> ParseInputPartTwo()
        {
            string input = File.ReadAllText(DayEightInputPath);
            List<string[]> parts = input.Split("\r\n").Select(s => s.Split(" | ")).ToList();
            return parts;
        }
    }
}