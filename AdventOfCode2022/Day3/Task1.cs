using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day3
{
    public class Task1 : IAdventOfCodeTask
    {
        public void Run()
        {
            var input = GetInput();
            var total = 0;

            foreach (var item in input)
            {
                var numOfItemsPerSack = item.Length / 2;
                var sack1 = item.Substring(0, numOfItemsPerSack);
                var sack2 = item.Substring(numOfItemsPerSack, numOfItemsPerSack);

                foreach(var c in sack1)
                {
                    if(sack2.Contains(c))
                    {
                        total += CalculateCharNumeric(c);
                        break;
                    }
                }
            }
            Console.WriteLine("The total sum of priorities is: {0}", total);
        }

        private int CalculateCharNumeric(char c)
        {
            var index = (int)c % 32; // gets the alpha position, eg 1,2,3
            if(Char.IsUpper(c))
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

