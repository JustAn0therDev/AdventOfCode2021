using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    internal class LanternFish
    {
        internal int DaysToCreateAnotherFish { get; set; }

        internal void ResetDays()
        {
            DaysToCreateAnotherFish = 7;
        }
    } 
    
    public class DaySix : AbstractDay
    {
        private const string DaySixInputPath = "Inputs\\daysix.txt";
        
        public override long PartOne()
        {
            string input = GetInput(DaySixInputPath)[0];
            string[] fishDays = input.Split(',');
            List<LanternFish> lanternFish = GetLanternFishFromInput(fishDays);

            for (int _ = 0; _ < 80; _++)
            {
                List<LanternFish> newFish = new();
                for (int i = 0; i < lanternFish.Count; i++)
                {
                    if (lanternFish[i].DaysToCreateAnotherFish == 0)
                    {
                        newFish.Add(new LanternFish { DaysToCreateAnotherFish = 8 });
                        lanternFish[i].ResetDays();
                    }
                    lanternFish[i].DaysToCreateAnotherFish--;
                }
                lanternFish.AddRange(newFish);
            }

            return lanternFish.Count;
        }
        
        public override long PartTwo()
        {
            // Credits to u/PaulCole710 for the simple solution. None of my solutions ran as fast as this one
            // and its pretty simple. Since I had no time to do this (work), I stopped and tried to understand the
            // simplest one. Pretty nice!
            string[] input = GetInput(DaySixInputPath)[0].Split(',');
            List<long> fishDays = new(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            long total = input.Length;

            foreach (string fishDay in input)
            {
                fishDays[(int)char.GetNumericValue(fishDay[0])] += 1;
            }
            
            for (int i = 0; i < 256; i++)
            {
                long tmp = fishDays[0];
                fishDays[0] = fishDays[1];
                fishDays[1] = fishDays[2];
                fishDays[2] = fishDays[3];
                fishDays[3] = fishDays[4];
                fishDays[4] = fishDays[5];
                fishDays[5] = fishDays[6];
                fishDays[6] = fishDays[7];
                fishDays[7] = fishDays[8];
                fishDays[6] += tmp;
                fishDays[8] = tmp;
                total += tmp;
            }
            return total;
        }

        private static List<LanternFish> GetLanternFishFromInput(string[] fishDays)
        {
            return fishDays.Select(s => new LanternFish { DaysToCreateAnotherFish = int.Parse(s)}).ToList();
        }
    }
}