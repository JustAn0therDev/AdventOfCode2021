using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    internal class SubmarineCost
    {
        internal int Cost { get; set; } = 1;
        internal int Total { get; set; }
    }
    
    public class DaySeven : AbstractDay
    {
        private const string DaySevenInputPath = "Inputs\\dayseven.txt";
        
        public override long PartOne()
        {
            long fuelCount = 0;

            List<int> submarinePositions = GetInput(DaySevenInputPath, ",").Select(s => int.Parse(s)).ToList();

            long goal = GetGoal(submarinePositions);

            int index = 0;
            
            while (submarinePositions.Any(a => a != goal))
            {
                int itemIndex = index % submarinePositions.Count;
                if (submarinePositions[itemIndex] < goal)
                {
                    submarinePositions[itemIndex]++;
                    fuelCount++;
                }
                else if (submarinePositions[itemIndex] > goal)
                {
                    submarinePositions[itemIndex]--;
                    fuelCount++;
                }

                index++;
            }

            return fuelCount;
        }

        public override long PartTwo()
        {
            long fuelCount = 0;

            List<int> submarinePositions = GetInput(DaySevenInputPath, ",").Select(s => int.Parse(s)).ToList();

            long goal = (long)Math.Floor((double)submarinePositions.Sum() / submarinePositions.Count);
            
            int index = 0;

            Dictionary<int, SubmarineCost> idxToTotalAndCost = new();
            Dictionary<int, bool> idxAligned = new();

            submarinePositions.ForEach(f => { 
                idxToTotalAndCost.Add(index, new SubmarineCost());
                idxAligned.Add(index, false);
                index++;
            });

            while (submarinePositions.Any(a => a != goal))
            {
                int itemIndex = index % submarinePositions.Count;
                if (submarinePositions[itemIndex] < goal)
                {
                    submarinePositions[itemIndex]++;
                    idxToTotalAndCost[itemIndex].Total += idxToTotalAndCost[itemIndex].Cost;
                    idxToTotalAndCost[itemIndex].Cost++;
                }
                else if (submarinePositions[itemIndex] > goal)
                {
                    submarinePositions[itemIndex]--;
                    idxToTotalAndCost[itemIndex].Total += idxToTotalAndCost[itemIndex].Cost;
                    idxToTotalAndCost[itemIndex].Cost++;
                }

                if (submarinePositions[itemIndex] == goal && !idxAligned[itemIndex])
                {
                    fuelCount += idxToTotalAndCost[itemIndex].Total;
                    idxAligned[itemIndex] = true;
                }

                index++;
            }

            return fuelCount;
        }
        
        private static long GetGoal(IReadOnlyCollection<int> positions)
        {
            return positions.OrderBy(o => o).ToList()[positions.Count/2];
        }
    }
}