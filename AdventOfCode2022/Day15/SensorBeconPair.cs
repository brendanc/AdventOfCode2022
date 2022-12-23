using System;
namespace AdventOfCode2022.Day15
{
	public class SensorBeconPair
	{
		public SensorBeconPair(Point sensor, Point beacon)
		{
			this.Sensor = sensor;
			this.Beacon = beacon;
		}

		public Point Sensor { get; set; }
		public Point Beacon { get; set; }

		public int Distance
		{
			get
			{
				return Sensor.DistanceFrom(Beacon);
			}
		}

		public bool SensorReachesY(int y)
		{
			return Math.Abs(Sensor.Y - y) <= Distance;
		}
	}
}

