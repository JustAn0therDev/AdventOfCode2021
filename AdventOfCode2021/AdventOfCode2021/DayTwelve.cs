namespace AdventOfCode2021;

// For this day, credits to Jonathan Paulson.
// Haven't managed to solve this day on time and his explanation of
// keeping state was really clarifying for me.
public class DayTwelve : AbstractDay
{
    //private const string DayTwelveInputPath = "Inputs\\daytwelve.test";
    private const string DayTwelveInputPath = "Inputs\\daytwelve.txt";
    
    public override long PartOne()
    {
        int paths = 0;
        IReadOnlyDictionary<string, List<string>> caves = GetInput();
        Queue<(string, HashSet<string>)> queue = new();
        
        queue.Enqueue(("start", new HashSet<string> { "start" }));

        while (queue.Count > 0)
        {
            (string vertex, HashSet<string> neighbors) = queue.Dequeue();
            
            if (vertex == "end")
            {
                paths++;
                continue;
            }
            
            foreach (string destination in caves[vertex])
            {
                if (!neighbors.Contains(destination))
                {
                    HashSet<string> newNeighbors = new(neighbors);
                    if (char.IsLower(destination[0]))
                    {
                        newNeighbors.Add(destination);
                    }
                    
                    queue.Enqueue((destination, newNeighbors));
                }
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
        int paths = 0;
        IReadOnlyDictionary<string, List<string>> caves = GetInput();
        Queue<(string, HashSet<string>, string?)> queue = new();
        
        queue.Enqueue(("start", new HashSet<string> { "start" }, null));

        while (queue.Count > 0)
        {
            (string vertex, HashSet<string> neighbors, string? visitedTwice) = queue.Dequeue();
            
            if (vertex == "end")
            {
                paths++;
                continue;
            }
            
            foreach (string destination in caves[vertex])
            {
                if (!neighbors.Contains(destination))
                {
                    HashSet<string> newNeighbors = new(neighbors);
                    if (char.IsLower(destination[0]))
                    {
                        newNeighbors.Add(destination);
                    }
                    
                    queue.Enqueue((destination, newNeighbors, visitedTwice));
                }
                else if (neighbors.Contains(destination) && visitedTwice is null &&
                         destination is not "end" && destination is not "start")
                {
                    queue.Enqueue((destination, neighbors, destination)); 
                }
            }
        }

        return paths;
    }
}
