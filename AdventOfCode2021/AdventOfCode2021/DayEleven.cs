namespace AdventOfCode2021;

internal static class ListExtensions
{
    internal static bool Has(this List<(int, int)> list, (int, int) toCheck)
    {
        foreach ((int item1, int item2) in list)
        {
            if (item1 == toCheck.Item1 && item2 == toCheck.Item2)
                return true;
        }

        return false;
    }
}

public class DayEleven : AbstractDay
{
    private const string DayElevenInputPath = "Inputs\\dayeleven.txt";

    private const int GridSize = 10;
    private const int MaxSteps = 100;

    public override long PartOne()
    {
        long result = 0;
        int[,] grid = GetInputGrid();
        int step = 1;

        while (step <= MaxSteps)
        {
            List<(int, int)> flashedThisStep = new();
            
            for (int i = 0; i < GridSize; i++)
            {  
                for (int j = 0; j < GridSize; j++)
                {
                    if (grid[i, j] == 9)
                    {
                        result += GetResultFromCell(grid, i, j, flashedThisStep);
                    } 
                    else if (!flashedThisStep.Has((i, j)))
                        grid[i, j]++;
                }
            }

            PrintGrid(grid);
            step++;
        }
        
        return result;
    }

    public override long PartTwo()
    {
        int[,] grid = GetInputGrid();
        int step = 1;

        while (true)
        {
            List<(int, int)> flashedThisStep = new();
            
            for (int i = 0; i < GridSize; i++)
            {  
                for (int j = 0; j < GridSize; j++)
                {
                    if (grid[i, j] == 9)
                    {
                        GetResultFromCell(grid, i, j, flashedThisStep);
                    } 
                    else if (!flashedThisStep.Has((i, j)))
                        grid[i, j]++;
                }
            }

            if (AllFlashed(grid))
                break;
            
            step++;
        }
        
        return step;
    }

    private static bool AllFlashed(int[,] grid)
    {
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                if (grid[i, j] != 0)
                    return false;
            }
        }
        return true;
    }

    private static int[,] GetInputGrid()
    {
        int[,] grid = new int[GridSize, GridSize];
        string[] lines = GetInput(DayElevenInputPath);

        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                grid[i, j] = (int)char.GetNumericValue(lines[i][j]);
            }
        }

        return grid;
    }

    private static int GetResultFromCell(int[,] grid, int i, int j, List<(int, int)> flashedThisStep)
    {
        int count = 1;
        bool canCheckLeft = j > 0;
        bool canCheckRight = j < GridSize - 1;
        bool canCheckDown = i < GridSize - 1;
        bool canCheckUp = i > 0;
        bool canCheckUpperRight = canCheckUp && canCheckRight;
        bool canCheckUpperLeft = canCheckUp && canCheckLeft;
        bool canCheckLowerRight = canCheckDown && canCheckRight;
        bool canCheckLowerLeft = canCheckDown && canCheckLeft;

        grid[i, j] = 0;
        flashedThisStep.Add((i, j));

        if (canCheckLeft)
        {
            if (grid[i, j - 1] == 9)
            {
                count += GetResultFromCell(grid, i, j - 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i, j - 1)))
            {
                grid[i, j - 1]++;
            }
        }

        if (canCheckRight)
        {
            if (grid[i, j + 1] == 9)
            {
                count += GetResultFromCell(grid, i, j + 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i, j + 1)))
            {
                grid[i, j + 1]++;
            }
        }

        if (canCheckUp)
        {
            if (grid[i - 1, j] == 9)
            {
                count += GetResultFromCell(grid, i - 1, j, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i - 1, j)))
            {
                grid[i - 1, j]++;
            }
        }

        if (canCheckDown)
        {
            if (grid[i + 1, j] == 9)
            {
                count += GetResultFromCell(grid, i + 1, j, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i + 1, j)))
            {
                grid[i + 1, j]++;
            }
        }
        
        if (canCheckLowerRight)
        {
            if (grid[i + 1, j + 1] == 9)
            {
                count += GetResultFromCell(grid, i + 1, j + 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i + 1, j + 1)))
            {
                grid[i + 1, j + 1]++;
            }
        }
        
        if (canCheckUpperRight)
        {
            if (grid[i - 1, j + 1] == 9)
            {
                count += GetResultFromCell(grid, i - 1, j + 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i - 1, j + 1)))
            {
                grid[i - 1, j + 1]++;
            }
        }

        if (canCheckLowerLeft)
        {
            if (grid[i + 1, j - 1] == 9)
            {
                count += GetResultFromCell(grid, i + 1, j - 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i + 1, j - 1)))
            {
                grid[i + 1, j - 1]++;
            }
        }
        
        if (canCheckUpperLeft)
        {
            if (grid[i - 1, j - 1] == 9)
            {
                count += GetResultFromCell(grid, i - 1, j - 1, flashedThisStep);
            }
            else if (!flashedThisStep.Has((i - 1, j - 1)))
            {
                grid[i - 1, j - 1]++;
            }
        }
        
        return count;
    }
 
    private static void PrintGrid(int[,] gridToPrint)
    {
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                Console.Write(gridToPrint[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}