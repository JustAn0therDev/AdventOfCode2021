using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    internal class Cell
    {
        internal int Value { get; set; }
        internal bool Marked { get; set; }
    } 
    
    public class DayFour : AbstractDay
    {
        private const int GridSize = 5;
        private readonly string DayFourInputPath = "Inputs\\dayfour_partone.txt";
        
        public override long PartOne()
        {
            string[] lines = File.ReadAllText(DayFourInputPath).Split('\n');
            
            ImmutableArray<int> draws = lines[0].Split(',').Select(s => int.Parse(s)).ToImmutableArray();

            List<Cell[,]> grids = GetGridsFromInput(lines.Where(static (_, i) => i > 1).ToList());

            foreach (int call in draws)
            {
                Mark(grids, call);

                for (int i = 0; i < grids.Count; i++)
                {
                    if (GridHasWon(grids[i]))
                    {
                        return GetSumOfAllUnmarked(grids[i]) * call;
                    }
                }
            }

            return 0;
        }

        public override long PartTwo()
        {
            string[] lines = File.ReadAllText(DayFourInputPath).Split('\n');
            
            ImmutableArray<int> draws = lines[0].Split(',').Select(s => int.Parse(s)).ToImmutableArray();

            List<Cell[,]> grids = GetGridsFromInput(lines.Where(static (_, i) => i > 1).ToList());

            Dictionary<int, bool> gridIndexWon = new();

            foreach (int call in draws)
            {
                Mark(grids, call);

                for (int i = 0; i < grids.Count; i++)
                {
                    if (GridHasWon(grids[i]))
                    {
                        gridIndexWon[i] = true;

                        if (gridIndexWon.Values.Count(w => w) == grids.Count)
                        {
                            return GetSumOfAllUnmarked(grids[i]) * call;
                        }
                    }
                }
            }

            return 0;
        }

        private List<Cell[,]> GetGridsFromInput(IReadOnlyList<string> lines)
        {
            List<Cell[,]> grids = new();
            
            for (int i = 0; i < lines.Count; i += 6)
            {
                string[] firstLine = lines[i].Split(' ').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Trim()).ToArray();
                string[] secondLine = lines[i + 1].Split(' ').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Trim()).ToArray();
                string[] thirdLine = lines[i + 2].Split(' ').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Trim()).ToArray();
                string[] fourthLine = lines[i + 3].Split(' ').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Trim()).ToArray();
                string[] fifthLine = lines[i + 4].Split(' ').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Trim()).ToArray();
                
                grids.Add(new Cell[,]
                {
                   {
                     new () { Value = int.Parse(firstLine[0]) }, 
                     new () { Value = int.Parse(firstLine[1]) },
                     new () { Value = int.Parse(firstLine[2]) },
                     new () { Value = int.Parse(firstLine[3]) },
                     new () { Value = int.Parse(firstLine[4]) }
                   },
                   {
                     new () { Value = int.Parse(secondLine[0]) }, 
                     new () { Value = int.Parse(secondLine[1]) },
                     new () { Value = int.Parse(secondLine[2]) },
                     new () { Value = int.Parse(secondLine[3]) },
                     new () { Value = int.Parse(secondLine[4]) }
                   },
                   {
                     new () { Value = int.Parse(thirdLine[0]) }, 
                     new () { Value = int.Parse(thirdLine[1]) },
                     new () { Value = int.Parse(thirdLine[2]) },
                     new () { Value = int.Parse(thirdLine[3]) },
                     new () { Value = int.Parse(thirdLine[4]) }
                   },
                   {
                     new () { Value = int.Parse(fourthLine[0]) }, 
                     new () { Value = int.Parse(fourthLine[1]) },
                     new () { Value = int.Parse(fourthLine[2]) },
                     new () { Value = int.Parse(fourthLine[3]) },
                     new () { Value = int.Parse(fourthLine[4]) }
                   },
                   {
                     new () { Value = int.Parse(fifthLine[0]) }, 
                     new () { Value = int.Parse(fifthLine[1]) },
                     new () { Value = int.Parse(fifthLine[2]) },
                     new () { Value = int.Parse(fifthLine[3]) },
                     new () { Value = int.Parse(fifthLine[4]) }
                   }
                }); 
            }

            return grids;
        }

        private void Mark(List<Cell[,]> grids, int number)
        {
            foreach (var grid in grids)
            {
                for (int i = 0; i < GridSize; i++)
                {
                    bool numberFound = false;
                    for (int j = 0; j < GridSize; j++)
                    {
                        if (grid[i, j].Value == number)
                        {
                            grid[i, j].Marked = true;
                            numberFound = true;
                            break;
                        }
                    }

                    if (numberFound)
                        break;
                }
            }
        }

        private static bool GridHasWon(Cell[,] grid, bool rows = false, bool columns = false)
        {
            //checking rows
            for (int row = 0; row < GridSize; row++)
            {
                bool won = true;
                for (int col = 0; col < GridSize; col++)
                {
                    if (!grid[row, col].Marked)
                    {
                        won = false;
                        break;
                    }
                }
                if (won)
                    return true;
            }
            
            //checking columns
            for (int col = 0; col < GridSize; col++)
            {
                bool won = true;
                for (int row = 0; row < GridSize; row++)
                {
                    if (!grid[row, col].Marked)
                    {
                        won = false;
                        break;
                    }
                }
                if (won)
                    return true;
            }
            return false;
        }

        private static long GetSumOfAllUnmarked(Cell[,] grid)
        {
            long total = 0;
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (!grid[i, j].Marked)
                        total += grid[i, j].Value;
                }
            }
            return total;
        }
    }
}