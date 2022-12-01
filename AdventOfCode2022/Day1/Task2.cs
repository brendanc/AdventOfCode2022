using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day1
{
	public class Task2 : IAdventOfCodeTask
	{
        public void Run()
        {
            Console.WriteLine("Welcome to Day 1, Task 2!");
            var input = InputReader.ReadInput("AdventOfCode2022.Day1.Input1.txt");

            var maxElves = new List<int>();
            var currentElf = 0;
            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        // new elf
                        if(maxElves.Count() != 3)
                        {
                            maxElves.Add(currentElf);
                        }
                        else
                        {
                            if(currentElf > maxElves.Min())
                            {
                                maxElves.Remove(maxElves.Min());
                                maxElves.Add(currentElf);
                            }
                        }
                  
                        currentElf = 0;
                    }
                    else
                    {
                        currentElf += Convert.ToInt32(line);
                    }
                }

            }

            Console.WriteLine("The top 3 elves are carrying {0} calories", maxElves.Sum());

        }
    }
}

