using System;
using System.Linq;

namespace AdventOfCode19.Day4
{
	public class Day4
	{
		public static void Run_1()
		{
			var min = 206938;
			var max = 679128;

			int count = 0;
			
			for (int i = min; i < 679128; ++i)
			{
				var str = i.ToString();
				if (IsIncreasing(str) && HasTwoAdjacent(str))
					++count;
			}
			Console.WriteLine(count);
		}

		private static bool HasAdjacent(string input)
		{
			return
				input[0] == input[1] ||
				input[1] == input[2] ||
				input[2] == input[3] ||
				input[3] == input[4] ||
				input[4] == input[5];
		}
		
		private static bool IsIncreasing(string input)
		{
			return
				input[1] >= input[0] &&
				input[2] >= input[1] &&
				input[3] >= input[2] &&
				input[4] >= input[3] &&
				input[5] >= input[4];
		}

		private static bool HasTwoAdjacent(string input)
		{
			int hasTwoAdjacent = 0;
			int hasTwoOrMore = 0;
			for (int i = 0; i < input.Length; ++i)
			{
				var count = Contains(input, input[i]);
				if (count == 2)
				{
					++hasTwoAdjacent;
				}
				else if (count > 2)
				{
					++hasTwoOrMore;
				}
			}

			if (hasTwoOrMore > 0 && hasTwoAdjacent > 0)
				return true;
			if (hasTwoOrMore > 0 && hasTwoAdjacent <= 0)
				return false;
			return hasTwoAdjacent > 0;
		}

		private static int Contains(string input, char search)
		{
			return input.Count(t => t == search);
		}
	}
}