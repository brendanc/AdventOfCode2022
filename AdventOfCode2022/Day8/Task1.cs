using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day8
{
    public class Task1 : AdventOfCodeTaskBase
    {

        public override void Run()
        {
            var input = GetInput().ToArray();
            var totalVisible = 0;

            var grid = new TreeGrid(input);

            for(var r=0;r<input.Length;r++)
            {
                var row = input[r];
                for(var c=0;c<row.Length;c++)
                {
                    var tree = row[c];
                    if (grid.TreeIsVisible(r, c))
                    {
                        totalVisible++;
                    }
                }
            }


            Console.WriteLine("Trees visible = " + totalVisible);
        }


    }
}
