using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day2
{
	public class Task2 : IAdventOfCodeTask
	{
        public void Run()
        {
            var input = GetInput();
            var total = 0;
            foreach(var match in input)
            {
                var opponent = match.Substring(0, 1);
                var desiredResult = match.Substring(2, 1);

                // figure out what I should play
                var me = GenerateMyPlay(opponent, desiredResult);

                total += new RockPaperScissorGame(opponent, me).Outcome;
            }
            Console.WriteLine("Match complete.  Total is {0}", total);
        }


        private string GenerateMyPlay(string opponent, string desiredResult)
        {
            switch (opponent)
            {
                case "A":
                    if(desiredResult == "Y") //tie
                    {
                        return "X";
                    }
                    if(desiredResult == "X") // loss
                    {
                        return "Z";
                    }
                    return "Y";
                case "B":
                    if (desiredResult == "Y") //tie
                    {
                        return "Y";
                    }
                    if (desiredResult == "X") // loss
                    {
                        return "X";
                    }
                    return "Z";
                case "C":
                    if (desiredResult == "Y") //tie
                    {
                        return "Z";
                    }
                    if (desiredResult == "X") // loss
                    {
                        return "Y";
                    }
                    return "X";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerable<string> GetInput()
        {
            return InputReader.ReadInputAsLines("AdventOfCode2022.Day2.Input1.txt");
        }
    }
}

