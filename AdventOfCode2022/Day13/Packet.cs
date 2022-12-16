using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2022.Day13
{
	public class Packet
	{
        private readonly string line;

        public PacketValue Value { get; set; }

        public Packet(string line)
		{
            this.line = line;
            var json = "{\"Items\":" + line + "}";
            Value = JsonConvert.DeserializeObject<PacketValue>(json);
        }

	}
}

