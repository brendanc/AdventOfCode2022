using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day10
{
	public class Task2 : AdventOfCodeTaskBase
	{

        public override void Run()
        {
            var input = GetInput();

            var device = new Device();

            foreach (var line in input)
            {
                device.Execute(line);
            }
            device.PrintCrt();
        }
    }
}

