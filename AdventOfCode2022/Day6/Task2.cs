using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day6
{
	public class Task2 : AdventOfCodeTaskBase
	{
        public override void Run()
        {
            var input = GetInputAsSingleString();
            

            const int messageLength = 14;
            var message = input.Substring(0, messageLength);

            for (var i = messageLength; i < input.Length; i++)
            {
                message = message.Substring(1, messageLength-1) + input[i];
                if (IsValidMessage(message))
                {
                    Console.WriteLine("Valid message found at char {0}", i + 1);
                    break;
                }
            }


        }

        /// <summary>
        /// Returns true if all 4 chars are unique
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool IsValidMessage(string message)
        {
            return message.Distinct().Count() == message.Length;
        }
    }
}

