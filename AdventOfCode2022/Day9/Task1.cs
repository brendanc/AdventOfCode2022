using System;
using System.Text.RegularExpressions;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day9
{
	public class Task1 : AdventOfCodeTaskBase
	{
        public override void Run()
        {
            //var input = @"R 4
            //U 4
            //L 3
            //D 1
            //R 4
            //D 1
            //L 5
            //R 2".Split('\n');
            var input = GetInput();

            var grid = new RopeGrid();
            var total = 0;
            foreach(var line in input)
            {
                var dir = line.Trim().Substring(0, 1);
                var num = Convert.ToInt32(Regex.Match(line.Trim(), @"\d+").Value);
                grid.Move(dir, num);
                var oldtotal = total;
                total = grid.TailPoints.Distinct().Count();
                Console.WriteLine("Head moved {0} to {1}", line, grid.Head.ToString());
                Console.WriteLine("Tail followed to {0}, total spaces now at {1}", grid.Tail.ToString(), total);
                var  x = ReadLine.Read("Press enter to make next move.");
            }
            Console.WriteLine("The tail hit {0} distinct points in the grid", grid.TailPoints.Distinct().Count());
        }
    }
}

