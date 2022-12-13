using System;
using AdventOfCode2022.Day9;

namespace AdventOfCode2022.Day12
{
	public class GridPosition
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Tuple<int, int> Pos => new Tuple<int, int>(X, Y);
		public char Value { get; set; }
		public int IntValue => Convert.ToInt32(Value);

		public bool IsStart => Value.Equals('S');
		public bool IsEnd => Value.Equals('E');

        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not RopePoint, return False
            if (!(obj is GridPosition))
            {
                return false;
            }

            var otherPoint = (GridPosition)obj;
            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

    }
}

