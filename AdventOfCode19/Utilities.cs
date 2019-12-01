using System.Collections.Generic;
using System.IO;

namespace AdventOfCode19
{
	public static class Utilities
	{
		public static List<string> ReadFile(string fileName)
		{
			List<string> strings = new List<string>();
			using var streamReader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read));

			while (!streamReader.EndOfStream)
				strings.Add(streamReader.ReadLine());

			return strings;
		}
	}
}