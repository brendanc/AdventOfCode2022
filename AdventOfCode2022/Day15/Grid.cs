using System;
using System.Diagnostics;

namespace AdventOfCode2022.Day15
{
	public class Grid
	{
		public Grid(IEnumerable<string> input)
		{
			Sensors = new List<Point>();
			Beacons = new List<Point>();
			Pairs = new HashSet<SensorBeconPair>();
			GridArray = new List<string>();

            foreach(var line in input)
			{
				var splits = line.Split('=');

				var sensor = new Point(Convert.ToInt32(splits[1].Split(',')[0].Trim()), Convert.ToInt32(splits[2].Split(':')[0].Trim()));
				Sensors.Add(sensor);

				var beacon = new Point(Convert.ToInt32(splits[3].Split(',')[0].Trim()), Convert.ToInt32(splits[4]));
				Beacons.Add(beacon);
				Pairs.Add(new SensorBeconPair(sensor, beacon));
			}

		//	PopulateGrid();
		}

		public List<Point> Sensors { get; set; }
		public List<Point> Beacons { get; set; }
		public HashSet<SensorBeconPair> Pairs { get; set; }
		public List<string> GridArray { get; set; }

		public int CalculateOpenPositions(int row)
		{
			var maxX = Math.Max(Pairs.Max(p => p.Sensor.X + p.Distance), Beacons.Max(b => b.X));
			var minX = Math.Min(Pairs.Min(p => p.Sensor.X - p.Distance), Beacons.Min(b => b.X));
			var total = 0;

            var points = new HashSet<Point>();
            for (var x = minX; x < maxX; x++)
			{
				points.Add(new Point(x, row));
			}

			foreach (var point in points)
			{
				if (Pairs.Any(p => p.Sensor.DistanceFrom(point) <= p.Distance)
					&& !Beacons.Contains(point)
					&& !Sensors.Contains(point))
				{
					total++;
				}
			}

			return total;
        }

		public void PopulateGrid()
		{
			var maxX = Math.Max(Sensors.Max(p => p.X), Beacons.Max(p => p.X));
			var minX = Math.Min(Sensors.Min(p => p.X), Beacons.Min(p => p.X));
            var maxY = Math.Max(Sensors.Max(p => p.Y), Beacons.Max(p => p.Y));
			var minY = Math.Min(Sensors.Min(p => p.Y), Beacons.Min(p => p.Y));


            for (int y=minY;y<maxY;y++)
			{
				var gridLine = "";
				for(var x=minX;x<maxX;x++)
				{
					var c = ".";
					var point = new Point(x, y);
					if(Sensors.Contains(point))
					{
						c = "S";
					}
					if(Beacons.Contains(point))
					{
						c = "B";
					}
					gridLine += c;
				}
				GridArray.Add(gridLine);
			}

			
		}
	}
}

