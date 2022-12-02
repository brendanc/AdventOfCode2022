using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day2
{
	public class Task1 : IAdventOfCodeTask
    { 
        public void Run()
        {
            var input = GetInput();
            var total = 0;
            foreach(var match in input)
            {
                var opponent = match.Substring(0, 1);
                var me = match.Substring(2, 1);
                total += new RockPaperScissorGame(opponent, me).Outcome;
            }
            Console.WriteLine("Match complete.  Total is {0}", total);
        }

        private IEnumerable<string> GetInput()
        {
            return InputReader.ReadInputAsLines("AdventOfCode2022.Day2.Input1.txt");
        }
    }
}

