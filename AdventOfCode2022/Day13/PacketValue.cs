using System;
namespace AdventOfCode2022.Day13
{
	public class PacketValue
	{
        private readonly string line;

        public PacketValue(string line)
		{
            this.line = line;
        }

        public PacketValue()
        {

        }

        public List<object> Items { get; set; }

        public override string ToString()
        {
            return line;
        }
    }
}

