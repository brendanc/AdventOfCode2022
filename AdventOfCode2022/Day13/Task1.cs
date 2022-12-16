using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day13
{
	public class Task1 : AdventOfCodeTaskBase
	{
        public override void Run()
        {
            var input = InputReader.ReadInput("AdventOfCode2022.Day13.Sample.txt");
            //var input = GetInputAsSingleString();
            var pairsInput = input.Split("\n\n");

            var pairs = new List<PacketPair>();

            foreach (var p in pairsInput)
            {
                var splits = p.Split('\n');
                var pair = new PacketPair(new Packet(splits[0]), new Packet(splits[1]));
                pairs.Add(pair);
            }

            var inOrderItems = new List<int>();
            for(var i=0;i<pairs.Count();i++)
            {
                if (pairs[i].IsInOrder())
                {
                    inOrderItems.Add(i + 1);
                }
            }

            Console.WriteLine("The sum of the in order indexes is {0}", inOrderItems.Sum());

        }
    }
}

