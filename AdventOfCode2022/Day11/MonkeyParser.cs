using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day11
{
	public class MonkeyParser
	{
		public MonkeyParser(IEnumerable<string> input)
		{
			Monkeys = new List<Monkey>();

			var blocks =  input
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 7)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();

			foreach(var block in blocks)
			{
                Monkey m = new Monkey();

                foreach(var line in block)
                {
                    if (line.Contains("Starting"))
                    {
                        var itemsString = line.Replace("Starting items:", "").Trim();
                        var items = itemsString.Split(',').Select(i => Convert.ToInt32(i)).ToList();
                        foreach(var item in items)
                        {
                            m.Items.Enqueue(item);
                        }
                    }
                    if(line.Contains("Operation"))
                    {
                        if (line.Contains("old * old"))
                        {
                            m.Operation = (x) => { return (long)Math.Pow(x, 2); };
                        }
                        else
                        {
                            var value = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                            m.Operation = (x) =>
                            {
                                if (line.Contains("+"))
                                {
                                    return x + value;
                                }
                                else
                                {
                                    return x * value;
                                }
                            };
                        }
                    }
                    if(line.Contains("Test"))
                    {
                        var value = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                        m.TestValue = value;
                    }
                    if(line.Contains("true"))
                    {
                        var value = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                        m.TrueMonkeyIndex = value;
                    }
                    if (line.Contains("false"))
                    {
                        var value = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                        m.FalseMonkeyIndex = value;
                    }
                }
                Monkeys.Add(m);
            }
		}

		public List<Monkey> Monkeys { get; set; }
	}
}

