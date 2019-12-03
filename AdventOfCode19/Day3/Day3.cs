using System;
using System.Collections.Generic;

namespace AdventOfCode19.Day3
{
	public class Position
	{
		public int X;
		public int Y;

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public class Day3
	{
		private const string FileName = "Day3\\input";

		public static void Run_1()
		{
			var input = Utilities.ReadFile(FileName).ToArray();

			var wireA = input[0].Split(',');
			var wireAPositions = new List<Position>();
			var wireAPosition = new Position(0, 0);

			//find the path of wire a
			for (int i = 0; i < wireA.Length; ++i)
			{
				var action = wireA[i];
				var range = Create(action, wireAPosition);
				wireAPositions.AddRange(range);
				wireAPosition = range[^1];
			}

			var wireB = input[1].Split(',');
			var wireBPositions = new List<Position>();
			var wireBPosition = new Position(0, 0);

			//find the path of wire b
			for (int i = 0; i < wireB.Length; ++i)
			{
				var action = wireB[i];
				var range = Create(action, wireBPosition);
				wireBPositions.AddRange(range);
				wireBPosition = range[^1];
			}

			//naive intersect search
			var intersections = new List<Position>();
			var steps = new List<Position>();
			for (int i = 0; i < wireAPositions.Count; ++i)
			{
				var currentWireAPosition = wireAPositions[i];
				for (int j = 0; j < wireBPositions.Count; ++j)
				{
					var currentWireBPosition = wireBPositions[j];
					if (IsEqual(currentWireAPosition, currentWireBPosition))
					{
						intersections.Add(currentWireBPosition);
						steps.Add(new Position(i+1, j+1));
					}
				}
			}
			
			int smallestDistance = int.MaxValue;
			for (int i = 0; i < intersections.Count; ++i)
			{
				var distance = Math.Abs(intersections[i].X) + Math.Abs(intersections[i].Y);
				if (smallestDistance > distance)
					smallestDistance = distance;
			}
			
			Console.WriteLine("smallestDistance " + smallestDistance);
			
			int smallestSteps = int.MaxValue;
			for (int i = 0; i < steps.Count; ++i)
			{
				var distance = Math.Abs(steps[i].X) + Math.Abs(steps[i].Y);
				if (smallestSteps > distance)
					smallestSteps = distance;
			}
			
			Console.WriteLine("smallestSteps " + smallestSteps);
		}

		private static bool IsEqual(Position a, Position b) => a.X == b.X && a.Y == b.Y;

		private static List<Position> Create(string input, Position currentPosition)
		{
			char direction = input[0];
			int distance = Convert.ToInt32(input.Substring(1, input.Length - 1));

			var positions = new List<Position>();
			
			switch (direction)
			{
				case 'L':
				{
					for (int i = 1; i <= distance; ++i)
					{
						positions.Add(new Position(currentPosition.X - i, currentPosition.Y));
					}

					return positions;
				}
				case 'R':
				{
					for (int i = 1; i <= distance; ++i)
					{
						positions.Add(new Position(currentPosition.X + i, currentPosition.Y));
					}

					return positions;
				}
				case 'U':
				{
					for (int i = 1; i <= distance; ++i)
					{
						positions.Add(new Position(currentPosition.X, currentPosition.Y + i));
					}

					return positions;
				}
				case 'D':
				{
					for (int i = 1; i <= distance; ++i)
					{
						positions.Add(new Position(currentPosition.X, currentPosition.Y - i));
					}

					return positions;
				}
				default:
					return positions;
			}
		}
	}
}