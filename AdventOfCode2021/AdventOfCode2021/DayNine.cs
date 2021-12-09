using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
	internal class Point
	{
		internal readonly int i;
		internal readonly int j;

		internal Point(int i, int j)
		{
			this.i = i;
			this.j = j;
		}
	}
	
	internal static class PointUtil
	{
		internal static bool HasPoint(this HashSet<Point> points, Point pointToCheck)
		{
			foreach (var point in points)
			{
				if (point.i == pointToCheck.i && point.j == pointToCheck.j)
					return true;
			}

			return false;
		}
	}
	
	public class DayNine : AbstractDay
	{
		private const string DayNineInputPath = "Inputs\\daynine.txt";

		public override long PartOne()
		{
			double result = 0;

			string[] lines = GetInput(DayNineInputPath);

			for (int i = 0; i < lines.Length; i++)
			{
				for (int j = 0; j < lines[i].Length; j++)
				{
					double current = char.GetNumericValue(lines[i][j]);
					bool canCheckLeft = j != 0;
					bool canCheckRight = j != lines[i].Length - 1;
					bool canCheckUp = i != 0;
					bool canCheckDown = i != lines.Length - 1;

					if (canCheckLeft)
					{
						double left = char.GetNumericValue(lines[i][j - 1]);
						if (left <= current)
							continue;
					}

					if (canCheckRight)
					{
						double right = char.GetNumericValue(lines[i][j + 1]);
						if (right <= current)
							continue;
					}

					if (canCheckUp)
					{
						double up = char.GetNumericValue(lines[i - 1][j]);
						if (up <= current)
							continue;
					}

					if (canCheckDown)
					{
						double down = char.GetNumericValue(lines[i + 1][j]);
						if (down <= current)
							continue;
					}

					result += current + 1;
				}
			}

			return (long)result;
		}

		public override long PartTwo()
		{
			string[] lines = GetInput(DayNineInputPath);

			HashSet<Point> checkedPoints = new();

			List<double> basins = new();

			for (int i = 0; i < lines.Length; i++)
			{
				for (int j = 0; j < lines[i].Length; j++)
				{
					double current = char.GetNumericValue(lines[i][j]);
					bool canCheckLeft = j != 0;
					bool canCheckRight = j != lines[i].Length - 1;
					bool canCheckUp = i != 0;
					bool canCheckDown = i != lines.Length - 1;

					if (canCheckLeft)
					{
						double left = char.GetNumericValue(lines[i][j - 1]);
						if (left <= current)
							continue;
					}

					if (canCheckRight)
					{
						double right = char.GetNumericValue(lines[i][j + 1]);
						if (right <= current)
							continue;
					}

					if (canCheckUp)
					{
						double up = char.GetNumericValue(lines[i - 1][j]);
						if (up <= current)
							continue;
					}

					if (canCheckDown)
					{
						double down = char.GetNumericValue(lines[i + 1][j]);
						if (down <= current)
							continue;
					}
					
					basins.Add(GetPointsRecursively(lines, checkedPoints, i, j));
				}
			}

			List<double>? threeLargestBasins = basins.OrderByDescending(od => od).Take(3).ToList();

			return (long) (threeLargestBasins[0] * threeLargestBasins[1] * threeLargestBasins[2]);
		}

		private static int GetPointsRecursively(string[] lines, HashSet<Point> checkedPoints, int i, int j)
		{
			int count = 1;

			checkedPoints.Add(new Point(i, j));

			double current = char.GetNumericValue(lines[i][j]);
			bool canCheckLeft = j != 0;
			bool canCheckRight = j != lines[i].Length - 1;
			bool canCheckUp = i != 0;
			bool canCheckDown = i != lines.Length - 1;

			if (canCheckLeft)
			{
				Point leftPoint = new(i, j - 1);
				double left = char.GetNumericValue(lines[i][j - 1]);
				if (left < 9 && left > current && !checkedPoints.HasPoint(leftPoint))
				{
					count += GetPointsRecursively(lines, checkedPoints, i, j - 1);
				}
			}

			if (canCheckRight)
			{
				Point rightPoint = new(i, j + 1);
				double right = char.GetNumericValue(lines[i][j + 1]);
				if (right < 9 && right > current && !checkedPoints.HasPoint(rightPoint))
				{
					count += GetPointsRecursively(lines, checkedPoints, i, j + 1);
				}
			}

			if (canCheckUp)
			{
				Point upPoint = new(i - 1, j);
				double up = char.GetNumericValue(lines[i - 1][j]);
				if (up < 9 && up > current && !checkedPoints.HasPoint(upPoint))
				{
					count += GetPointsRecursively(lines, checkedPoints, i - 1, j);
				}
			}

			if (canCheckDown)
			{
				Point downPoint = new(i + 1, j);
				double down = char.GetNumericValue(lines[i + 1][j]);
				if (down < 9 && down > current && !checkedPoints.HasPoint(downPoint))
				{
					count += GetPointsRecursively(lines, checkedPoints, i + 1, j);
				}
			}

			return count;
		}
	}
}
