using System;
using System.Linq;
using System.Threading;

namespace AdventOfCode19.Day2
{
	public struct Opcodes
	{
		public const int Add = 1;
		public const int Mult = 2;
		public const int HCF = 99;
	}

	public class Day2
	{
		private const int Step = 4;

		public static void Run_1()
		{
			var str = Utilities.ReadFile("Day2\\input")
				.First()
				.Split(',')
				.Select(s => Convert.ToInt32(s))
				.ToArray();

			var originalMemory = new int[str.Length];
			str.CopyTo(originalMemory, 0);

			int opcodes = str.Length;
			int pc = 0;

			int finalNoun = 0;
			int finalVerb = 0;
			
			for (int noun = 0; noun <= 99; ++noun)
			{
				for (int verb = 0; verb <= 99; ++verb)
				{
					originalMemory.CopyTo(str, 0);
					pc = 0;

					str[1] = noun;
					str[2] = verb;
					
					while (true)
					{
						int action = str[pc];

						++pc;

						//overflow check
						pc = Overflow(pc, opcodes);

						int val1 = str[pc];

						++pc;

						pc = Overflow(pc, opcodes);

						//overflow check
						int val2 = str[pc];

						++pc;

						pc = Overflow(pc, opcodes);

						//overflow check
						int memloc1 = str[pc];

						++pc;

						pc = Overflow(pc, opcodes);

						//overflow check

						if (action == Opcodes.Add)
						{
							str[memloc1] = str[val1] + str[val2];
						}
						else if (action == Opcodes.Mult)
						{
							str[memloc1] = str[val1] * str[val2];
						}
						else if (action == Opcodes.HCF)
						{
							 break;
						}
					}
					
					if (str[0] == 19690720)
					{
						finalNoun = noun;
						finalVerb = verb;
						goto Done;
					}
				}
			}
			
			Done:
			Console.WriteLine(str[0]);
		}

		private static int Overflow(int pc, int max)
		{
			if (pc >= max)
				return pc - max;
			return pc;
		}
	}
}