using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day4
{
    public class Task1 : AdventOfCodeTaskBase
    {
        public override void Run()
        {
            var total = 0;
            foreach(var line in GetInput())
            {
                var pairs = line.Split(',').Select(x => new ElfPair(x));

                if(DoPairsOverlap(pairs))
                {
                    total++;
                }
            }
            Console.WriteLine("{0} overlap", total);
        }

        /// <summary>
        /// Check for total overlap
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        private bool DoPairsOverlap(IEnumerable<ElfPair> pairs)
        { 
            if (pairs.ElementAt(0).Range == pairs.ElementAt(1).Range)
            {
                // if they have the same range they must be total equals to
                return pairs.ElementAt(0).MaxNumber == pairs.ElementAt(1).MaxNumber &&
                    pairs.ElementAt(0).MinNumber == pairs.ElementAt(1).MinNumber;
            }

            var larger = pairs.OrderByDescending(p => p.Range).First();
            var smaller = pairs.OrderBy(p => p.Range).First();

            return larger.MinNumber <= smaller.MinNumber && larger.MaxNumber >= smaller.MaxNumber;
        }
    }
}

