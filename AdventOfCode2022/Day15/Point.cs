using System;


namespace AdventOfCode2022.Day15
{
	public class Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X {get;set;}
		public int Y { get; set; }

        public int DistanceFrom(Point pt)
        {
            return Math.Abs(this.X - pt.X) + Math.Abs(this.Y - pt.Y);
        }

        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not RopePoint, return False
            if (!(obj is Point))
            {
                return false;
            }

            var otherPoint = (Point)obj;
            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}

