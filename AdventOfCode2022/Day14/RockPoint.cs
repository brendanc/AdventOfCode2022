using System;
namespace AdventOfCode2022.Day14
{
	public class RockPoint
	{

		public RockPoint(string points)
		{
			var splits = points.Split(',');
			X = Convert.ToInt32(splits[0]);
			Y = Convert.ToInt32(splits[1]);
		}

		public RockPoint()
		{

		}

        public RockPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

		public int X { get; set; }
		public int Y { get; set; }

        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not RopePoint, return False
            if (!(obj is RockPoint))
            {
                return false;
            }

            var otherPoint = (RockPoint)obj;
            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}

