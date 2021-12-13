namespace AdventOfCode2021;

// For this day, credits to "Jonathan Paulson". His explanation and solution made me understand how to traverse graphs
// and check every possible edge and vertex combination.
// The current solution is mine. Instead of having an adjacency list to check the possible nodes,
// I'm using DFS to know which neighbors have already been visited and when we got to the end.
public class DayTwelve : AbstractDay
{
    private const string DayTwelveInputPath = "Inputs\\daytwelve.txt";
    
    public override long PartOne()
    {
        IReadOnlyDictionary<string, List<string>> caves = GetInput();
        return DFSPartOne("start", caves, new HashSet<string> { "start" });
    }

    private static int DFSPartOne(string source, IReadOnlyDictionary<string, List<string>> caves, ISet<string> neighbors)
    {
        int paths = 0;

        if (source == "end")
        {
            paths++;
            return paths;
        }
        
        foreach (string destination in caves[source])
        {
            if (!neighbors.Contains(destination))
            {
                HashSet<string> newVisited = new(neighbors);
                
                if (char.IsLower(destination[0]))
                    newVisited.Add(destination);
                
                paths += DFSPartOne(destination, caves, newVisited);
            }
        }

        return paths;
    }

    private static IReadOnlyDictionary<string, List<string>> GetInput()
    {
        string[] input = GetInput(DayTwelveInputPath);

        Dictionary<string, List<string>> caves = new();

        foreach (string line in input)
        {
            string[] caveNames = line.Split('-');
            (string source, string dest) = (caveNames[0], caveNames[1]);

            if (source == "end" || dest == "start")
            {
                (source, dest) = (dest, source);
            }
            
            if ((source == "start" || dest == "start") && !caves.ContainsKey("start"))
                caves.Add("start", new List<string> { "start" });

            if (caves.ContainsKey(source))
            {
                caves[source].Add(dest);
            }
            else
            {
                caves.Add(source, new List<string>() { dest });
            }

            if (caves.ContainsKey(dest))
            {
                caves[dest].Add(source);
            }
            else
            {
                caves.Add(dest, new List<string>() { source });
            }
        }

        return caves;
    }
    
    public override long PartTwo()
    {
        IReadOnlyDictionary<string, List<string>> caves = GetInput();
        return DFSPartTwo("start", caves, new HashSet<string> { "start" }, visitedTwice: false);
    }

    private static int DFSPartTwo(string source, IReadOnlyDictionary<string, List<string>> caves,
        ISet<string> neighbors, bool visitedTwice)
    {
        int paths = 0;

        if (source == "end")
        {
            paths++;
            return paths;
        }
        
        foreach (string destination in caves[source])
        {
            if (!neighbors.Contains(destination))
            {
                HashSet<string> newVisited = new(neighbors);
                
                if (char.IsLower(destination[0]))
                    newVisited.Add(destination);
                
                paths += DFSPartTwo(destination, caves, newVisited, visitedTwice);
            } else if (destination is not "start" and not "end" && !visitedTwice)
            {
                paths += DFSPartTwo(destination, caves, neighbors, visitedTwice: true);
            }
        }

        return paths;
    }
}
