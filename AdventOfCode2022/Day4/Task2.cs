using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day4
{
    public class Task2 : AdventOfCodeTaskBase
    {
        public override void Run()
        {
            var total = 0;
            foreach (var line in GetInput())
            {
                var pairs = line.Split(',').Select(x => new ElfPair(x));

                if (DoPairsOverlap(pairs))
                {
                    total++;
                }
            }
            Console.WriteLine("{0} overlap", total);
        }

        /// <summary>
        /// Check for any amount of overlap
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        private bool DoPairsOverlap(IEnumerable<ElfPair> pairs)
        {
            var overlap = pairs.ElementAt(0).FullCollection.Intersect(pairs.ElementAt(1).FullCollection);
            return overlap != null && overlap.Count() > 0;
        }
    }
}

