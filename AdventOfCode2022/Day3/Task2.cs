using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day3
{
	public class Task2 : IAdventOfCodeTask
	{
        public void Run()
        {
            var input = GetInput();
            var total = 0;


            var sets = input.Chunk(3);
            foreach(var set in sets)
            {
                var common = set[0].Intersect(set[1]).Intersect(set[2]);
                total += CalculateCharNumeric(common.First());
            }

            Console.WriteLine("The total sum of priorities is: {0}", total);
        }

        private int CalculateCharNumeric(char c)
        {
            var index = (int)c % 32; // gets the alpha position, eg 1,2,3
            if (Char.IsUpper(c))
            {
                index += 26;
            }
            return index;
        }

        private IEnumerable<string> GetInput()
        {
            return InputReader.ReadInputAsLines("AdventOfCode2022.Day3.Input1.txt");
        }
    }
}

