using System;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Day10
{
	public class Device
	{
        private int[] KeyCycles = new int[] { 20, 60, 100, 140, 180, 220 };
		private const string sprite = "###";
		private const int lineLength = 40;
		private int cycle;

        public Device()
		{
			X = 1;
			CurrentCycle = 0;
			KeySignals = new Dictionary<int, int>();
			Crt = new string('.', 240);
        }

		public int CurrentCycle
		{
			get
			{
				return cycle;
			}
			set
			{
				cycle = value;
				if(cycle == 0)
				{
					return;
				}
				UpdateCrt();
                if (KeyCycles.Contains(cycle))
                {
                    KeySignals.Add(cycle, this.SignalStrength);
                    Console.WriteLine("Value at Key Cycle {0} is {1}", cycle, this.X);
                }
            }
		}

		public int X { get; set; }
        public Dictionary<int, int> KeySignals { get; set; }
		public string Crt { get; set; }

		public void UpdateCrt()
		{
			var pos = (CurrentCycle < 40 ? CurrentCycle : CurrentCycle % 40)-1;
			var diff = Math.Abs(this.X - pos);
			if (diff <= 1)
			{
                // sprite is visible
                var sb = new StringBuilder(Crt);
                sb[CurrentCycle - 1] = '#';
                Crt = sb.ToString();
            }

        }

		public void PrintCrt()
		{
            StringBuilder builder = new StringBuilder();
            for (var index = 0; index < Crt.Length; index += lineLength)
            {
                builder.Append(Crt, index, lineLength);
                builder.Append('\n');
            }
			Console.WriteLine(builder.ToString());

        }

		public void Execute(string command)
		{
            if (command == "noop")
            {
				CurrentCycle++;
                // do nothing
                return;
            }

			var splits = command.Split(' ');
			var commandText = splits[0];
			var commandValue = Convert.ToInt32(splits[1]);

			if(commandText == "addx")
			{
				CurrentCycle++;
				CurrentCycle++;
				X += commandValue;
			}
		}

		public int SignalStrength
		{
			get
			{
				return CurrentCycle * X;
			}
		}
	}
}

