using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day10
{
	public class Task1 : AdventOfCodeTaskBase
	{


        public override void Run()
        {
            var input = GetInput();
            //var input = InputReader.ReadInputAsLines("AdventOfCode2022.Day10.Sample.txt");


           var device = new Device();

           foreach (var line in input)
           {
                device.Execute(line);
           }

            var total = device.KeySignals.Sum(s => s.Value);
            Console.WriteLine("Total signal strength key cycles is {0}", total);
        }
    }
}

