using System;
using System.Linq;

namespace AdventOfCode19.Day1
{
	public class Day1
	{
		private const string FileName = "Day1\\input";
		
		public static int Run_1()
		{
			var input = Utilities.ReadFile(FileName).Select(i => Convert.ToInt32(i));
			return input.Sum(CalculateFuel);
		}

		public static int Run_2()
		{
			var input = Utilities.ReadFile(FileName).Select(i => Convert.ToInt32(i));
			return input.Sum(CalculateFuelRecursive);
		}

		private static int CalculateFuel(int mass) => (mass / 3) - 2;

		private const int Threshold = 0;
		private static int CalculateFuelRecursive(int fuel)
		{
			var load = CalculateFuel(fuel);

			if (load <= Threshold)
				return 0;
			
			return load + CalculateFuelRecursive(load);
		}
	}
}