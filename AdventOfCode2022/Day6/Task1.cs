using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day6
{
	public class Task1 : AdventOfCodeTaskBase
	{
        public override void Run()
        {
            var input = GetInputAsSingleString();


            const int markerLength = 4;
            var marker = input.Substring(0, markerLength);

            for(var i= markerLength; i<input.Length;i++)
            {
                marker = marker.Substring(1, markerLength-1) + input[i];
                if(IsValidMarker(marker))
                {
                    Console.WriteLine("Valid marker found at char {0}", i+1);
                    break;
                }
            }


        }

        /// <summary>
        /// Returns true if all 4 chars are unique
        /// </summary>
        /// <param name="market"></param>
        /// <returns></returns>
        private bool IsValidMarker(string marker)
        {
            return marker.Distinct().Count() == marker.Length;
        }
    }
}

