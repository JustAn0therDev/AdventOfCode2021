using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    internal class Coordinates
    {
        internal int BeginX { get; init; }
        internal int BeginY { get; init; }
        internal int EndX { get; init; }
        internal int EndY { get; init; }

        public IEnumerable<(int, int)> GetCoveredPointsPartOne()
        {
            List<(int, int)> covers = new();

            if (BeginX == EndX)
            {
                IEnumerable<int> yPoints = EndY > BeginY ? Enumerable.Range(BeginY, EndY - BeginY + 1) : Enumerable.Range(EndY, BeginY - EndY + 1);
                foreach (int point in yPoints)
                {
                    covers.Add((BeginX, point));
                }
            }
            // In part 1, either Y1 == Y2 or X1 == X2
            else
            {
                IEnumerable<int> xPoints = EndX > BeginX ? Enumerable.Range(BeginX, EndX - BeginX + 1) : Enumerable.Range(EndX, BeginX - EndX + 1);
                foreach (int point in xPoints)
                {
                    covers.Add((point, BeginY));
                }
            }

            return covers;
        }

        public IEnumerable<(int, int)> GetCoveredPointsPartTwo()
        {
            List<(int, int)> covers = new();

            if (BeginX == EndX)
            {
                IEnumerable<int> yPoints = EndY > BeginY ? Enumerable.Range(BeginY, EndY - BeginY + 1) : Enumerable.Range(EndY, BeginY - EndY + 1);
                foreach (int point in yPoints)
                {
                    covers.Add((BeginX, point));
                }
            }
            else if (BeginY == EndY)
            {
                IEnumerable<int> xPoints = EndX > BeginX ? Enumerable.Range(BeginX, EndX - BeginX + 1) : Enumerable.Range(EndX, BeginX - EndX + 1);
                foreach (int point in xPoints)
                {
                    covers.Add((point, BeginY));
                }
            }
            //covering diagonal points.
            else
            {
                List<int> xPoints = (EndX > BeginX ? Enumerable.Range(BeginX, EndX - BeginX + 1) : Enumerable.Range(EndX, BeginX - EndX + 1)).ToList();
                List<int> yPoints = (EndY > BeginY ? Enumerable.Range(BeginY, EndY - BeginY + 1) : Enumerable.Range(EndY, BeginY - EndY + 1)).ToList();

                if (BeginX >= EndX)
                    xPoints.Reverse();

                if (BeginY >= EndY)
                    yPoints.Reverse();

                for (int i = 0; i < xPoints.Count; i++)
                {
                    covers.Add((xPoints[i], yPoints[i]));
                }
            }

            return covers;
        }
        
        public override string ToString()
        {
            return $"{BeginX.ToString()}, {BeginY.ToString()} -> {EndX.ToString()}, {EndY.ToString()}";
        }
    } 
    
    public class DayFive : AbstractDay
    {
        private const string DayFiveInputPath = "inputs\\dayfive_partone.txt";
        
        public override long PartOne()
        {
            long intersections = 0;
            string[] input = GetInput(DayFiveInputPath);
            List<Coordinates> allCoords = new();
            
            foreach (var line in input)
            {
                Coordinates coords = GetParsedPointsFromLine(line);
                if (CoordinatesTraverseOnlyLines(coords))
                {
                    allCoords.Add(coords);
                }
            }

            intersections += GetAllIntersections(allCoords);
            
            return intersections;
        }

        public override long PartTwo()
        {
            long intersections = 0;
            string[] input = GetInput(DayFiveInputPath);
            List<Coordinates> allCoords = new();
            
            foreach (string line in input)
            {
                Coordinates coords = GetParsedPointsFromLine(line);
                allCoords.Add(coords);
            }

            intersections += GetAllIntersectionsPartTwo(allCoords);
            
            return intersections;
        }


        private static bool CoordinatesTraverseOnlyLines(Coordinates coords) => coords.BeginX == coords.EndX || coords.BeginY == coords.EndY;

        private static Coordinates GetParsedPointsFromLine(string line)
        {
            string[] points = line.Replace(" -> ", " ").Split(' ');
            string[] beginCoordinatesCoordinates = points[0].Split(',');
            string[] endCoordinatesCoordinates = points[1].Split(',');
            return new Coordinates
            {
                BeginX = int.Parse(beginCoordinatesCoordinates[0]),
                BeginY = int.Parse(beginCoordinatesCoordinates[1]),
                EndX = int.Parse(endCoordinatesCoordinates[0]),
                EndY = int.Parse(endCoordinatesCoordinates[1])
            };
        }
        
        private static int GetAllIntersections(IReadOnlyList<Coordinates> allCoords)
        {
            HashSet<(int, int)> intersections = new();
            for (int i = 0; i < allCoords.Count; i++)
            {
                for (int j = 0; j < allCoords.Count; j++)
                {
                    if (i == j)
                        continue;
                    
                    IEnumerable<(int, int)> iCoveredPoints = allCoords[i].GetCoveredPointsPartOne();
                    IEnumerable<(int, int)> jCoveredPoints = allCoords[j].GetCoveredPointsPartOne();
                    HashSet<(int, int)> foundIntersections = new(iCoveredPoints.Intersect(jCoveredPoints));

                    if (foundIntersections.Any())
                    {
                        foreach ((int, int) intersection in foundIntersections)
                            intersections.Add(intersection);
                    }
                }
            } 
            return intersections.Count;
        }
        
        private static long GetAllIntersectionsPartTwo(IReadOnlyList<Coordinates> allCoords)
        {
            HashSet<(int, int)> intersections = new();
            for (int i = 0; i < allCoords.Count; i++)
            {
                for (int j = 0; j < allCoords.Count; j++)
                {
                    if (i == j)
                        continue;
                    
                    IEnumerable<(int, int)> iCoveredPoints = allCoords[i].GetCoveredPointsPartTwo();
                    IEnumerable<(int, int)> jCoveredPoints = allCoords[j].GetCoveredPointsPartTwo();
                    HashSet<(int, int)> foundIntersections = new(iCoveredPoints.Intersect(jCoveredPoints));
                    
                    if (foundIntersections.Any())
                        foreach ((int, int) intersection in foundIntersections)
                            intersections.Add(intersection);
                }
            }
            return intersections.Count;
        }
    }
}