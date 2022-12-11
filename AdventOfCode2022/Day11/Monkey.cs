using System;
namespace AdventOfCode2022.Day11
{
	public class Monkey
	{
		public Monkey()
		{
			Items = new Queue<long>();
		}

		public Queue<long> Items { get; set; }
		public Func<long,long> Operation { get; set; }
		public long TestValue { get; set; }
		public int TrueMonkeyIndex { get; set; }
		public int FalseMonkeyIndex { get; set; }
		public long ItemsInspected { get; set; }
	}
}

