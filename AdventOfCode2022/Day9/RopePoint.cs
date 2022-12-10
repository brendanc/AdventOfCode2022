using System;
namespace AdventOfCode2022.Day9
{
	public class RopePoint
	{
		public RopePoint(int x, int y)
		{
            this.X = x;
            this.Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }

        public bool IsAdjacentTo(RopePoint point)
        {
            return Math.Abs(this.X - point.X) <= 1 && Math.Abs(this.Y - point.Y) <= 1;
        }


        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not RopePoint, return False
            if (!(obj is RopePoint))
            {
                return false;
            }

            var otherPoint = (RopePoint)obj;
            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }


    }
}

