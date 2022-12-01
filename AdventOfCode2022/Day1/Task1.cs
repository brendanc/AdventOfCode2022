using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day1
{
    public class Task1 : IAdventOfCodeTask
    {
        public void Run()
        {
            Console.WriteLine("Welcome to Day 1, Task 1!");
            var input = InputReader.ReadInput("AdventOfCode2022.Day1.Input1.txt");

            var maxElf = 0;
            var currentElf = 0;
            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        // new elf
                        if (currentElf > maxElf)
                        {
                            maxElf = currentElf;
                        }
                        currentElf = 0;
                    }
                    else
                    {
                        currentElf += Convert.ToInt32(line);
                    }
                }

            }

            Console.WriteLine("The max elf has {0} calories", maxElf);

        }
    }
}
