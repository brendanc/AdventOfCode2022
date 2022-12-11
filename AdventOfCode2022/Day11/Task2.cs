using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day11
{
	public class Task2 : AdventOfCodeTaskBase
	{
        public override void Run()
        {
            var input = InputReader.ReadInputAsLines("AdventOfCode2022.Day11.Sample.txt");
            //var input = GetInput();
            var parser = new MonkeyParser(input);

            var monkeys = parser.Monkeys;

            // the test values are prime, so to reduce worry while still keeping the % accurate
            // aggregate all the test values into a large number and % by that factor
            long factor = 1;
            foreach(var m in monkeys)
            {
                factor *= m.TestValue;
            }
            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.Count() > 0)
                    {
                        monkey.ItemsInspected++;
                        var item = monkey.Items.Dequeue();
                        var value = monkey.Operation(item);
                        value %= factor;
                        if (value % monkey.TestValue == 0)
                        {
                            monkeys[monkey.TrueMonkeyIndex].Items.Enqueue(value);
                        }
                        else
                        {
                            monkeys[monkey.FalseMonkeyIndex].Items.Enqueue(value);
                        }
                    }
                }
            }

            var top2 = monkeys.OrderByDescending(m => m.ItemsInspected).Take(2);
            var answer = top2.ElementAt(0).ItemsInspected * top2.ElementAt(1).ItemsInspected;
            Console.WriteLine("Level of monkey business = " + answer);
        }
    }
}


