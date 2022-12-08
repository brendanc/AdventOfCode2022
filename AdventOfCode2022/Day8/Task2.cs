using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day8
{
    public class Task2 : AdventOfCodeTaskBase
    {
        public override void Run()
        {
            var input = GetInput().ToArray();
            var maxScore = 0;

            var grid = new TreeGrid(input);

            for (var r = 0; r < input.Length; r++)
            {
                var row = input[r];
                for (var c = 0; c < row.Length; c++)
                {
                    var score = grid.GetScenicScore(r, c);
                    if(score > maxScore)
                    {
                        maxScore = score;
                    }

                }
            }


            Console.WriteLine("Max scenic score = " + maxScore);
        }
    }
}
