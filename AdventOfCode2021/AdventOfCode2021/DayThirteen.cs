using System.Text;

namespace AdventOfCode2021;

public class DayThirteen : AbstractDay
{
    private const string DayThirteenInputPath = "Inputs\\daythirteen.txt";

    public override long PartOne()
    {
        (HashSet<(int, int)> pointCoordinates, List<(char, int)> foldInstructions) = GetInput();

        (char axis, int foldFrom) = foldInstructions[0];
        
        int maxX = pointCoordinates.Max(m => m.Item1);
        int maxY = pointCoordinates.Max(m => m.Item2);
        
        if (axis == 'x')
        {
            HashSet<(int, int)> biggerX = new(pointCoordinates.Where(w => w.Item1 > foldFrom));
            pointCoordinates.RemoveWhere(w => w.Item1 > foldFrom);
            foreach ((int x, int y) in biggerX)
                pointCoordinates.Add((maxX - x, y));
        }
        else
        {
            HashSet<(int, int)> biggerY = new(pointCoordinates.Where(w => w.Item2 > foldFrom));
            pointCoordinates.RemoveWhere(w => w.Item2 > foldFrom);
            foreach ((int x, int y) in biggerY)
                pointCoordinates.Add((x, maxY - y));
        }

        return pointCoordinates.Count;
    }

    public override long PartTwo()
    {
        (HashSet<(int, int)> pointCoordinates, List<(char, int)> foldInstructions) = GetInput();
        foreach ((char axis, int foldFrom) in foldInstructions)
        {
            int maxX = pointCoordinates.Max(m => m.Item1);
            int maxY = pointCoordinates.Max(m => m.Item2);

            if (axis == 'x')
            {
                HashSet<(int, int)> biggerX = new(pointCoordinates.Where(w => w.Item1 > foldFrom));
                pointCoordinates.RemoveWhere(w => w.Item1 > foldFrom);
                foreach ((int x, int y) in biggerX)
                    pointCoordinates.Add((foldFrom - (x - foldFrom), y));
            }
            else
            {
                HashSet<(int, int)> biggerY = new(pointCoordinates.Where(w => w.Item2 > foldFrom));
                pointCoordinates.RemoveWhere(w => w.Item2 > foldFrom);
                foreach ((int x, int y) in biggerY)
                    pointCoordinates.Add((x, foldFrom - (y - foldFrom)));
            }
        }
        
        Draw(pointCoordinates);
        
        return pointCoordinates.Count;
    }

    private static void Draw(IReadOnlySet<(int, int)> pointCoordinates)
    {
        StringBuilder sb = new();
        int maxX = pointCoordinates.Max(m => m.Item1);
        int maxY = pointCoordinates.Max(m => m.Item2);

        for (int y = 0; y < maxY + 1; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                sb.Append(pointCoordinates.Contains((x, y)) ? " #" : " .");
            }
            Console.WriteLine(sb);
            sb.Clear();
        }
    }

    private static (HashSet<(int, int)>, List<(char, int)>) GetInput()
    {
        string[] input = GetInput(DayThirteenInputPath);
        List<(char, int)> foldInstructions = new();
        HashSet<(int, int)> pointCoordinates = new();

        bool inFoldInstructions = false;

        foreach (string line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                inFoldInstructions = true;
                continue;
            }

            if (inFoldInstructions)
            {
                string[] instruction = line.Split('=');
                foldInstructions.Add((instruction[0][instruction[0].Length - 1], int.Parse(instruction[1])));
            }
            else
            {
                string[] data = line.Split(',');
                pointCoordinates.Add((int.Parse(data[0]), int.Parse(data[1])));
            }
        }
        
        return (pointCoordinates, foldInstructions);
    }
}