using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day14
{
	public class Task1 : AdventOfCodeTaskBase
    {
        public override void Run()
        {
            //var input = "498,4 -> 498,6 -> 496,6\n503,4 -> 502,4 -> 502,9 -> 494,9".Split('\n');
            var input = GetInput();
            var grid = new RockGrid(input);

            var total = 0;

            while(grid.DropSand() == false)
            {
                total++;
            }

            Console.WriteLine("Total sands dropped = {0}", total);
        }
    }
}

