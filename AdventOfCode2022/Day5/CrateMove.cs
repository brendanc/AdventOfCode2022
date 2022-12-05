using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day5
{
	public class CrateMove
	{
		public CrateMove(string row)
		{
			MoveString = row;
            var numbers = Regex.Matches(row, @"\d+")
                   .Cast<Match>()
                   .Select(m => Convert.ToInt32(m.Value))
                   .ToList();
			NumberToMove = numbers[0];
			From = numbers[1];
			To = numbers[2];
        }

		public int NumberToMove { get; set; }
		public int From { get; set; }
		public int To { get; set; }
		public string MoveString { get; set; }

        public static List<CrateMove> ParseMoves(IEnumerable<string> input)
        {
            var output = new List<CrateMove>();
            foreach (var line in input)
            {
                if (line.StartsWith("move") == false)
                {
                    continue;
                }
                output.Add(new CrateMove(line));
            }
            return output;
        }
    }
}

