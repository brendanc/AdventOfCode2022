using System;
namespace AdventOfCode2022.Day9
{
	public class RopeGrid
	{
		public RopeGrid()
		{
			this.Head = new RopePoint(0, 0);
			this.Tail = new RopePoint(0, 0);
            this.TailPoints = new List<RopePoint>() { new RopePoint(0, 0) };
        }

		public RopePoint Head { get; set; }
		public RopePoint Tail { get; set; }

		public void Move(string direction, int value)
		{
            switch (direction)
            {
                case "R":
                    this.Head.X += value;
                    break;
                case "L":
                   this.Head.X -= value;
                    break;
                case "U":
                    this.Head.Y += value;
                    break;
                case "D":
                    this.Head.Y -= value;
                    break;
                default:
                    throw new ArgumentException("Invalid direction!");
            }
            MoveTail();
        }

		/// <summary>
		/// Move tail to catch up to Head
		/// </summary>
		private void MoveTail()
		{
            if(Head.IsAdjacentTo(Tail))
            {
                // do nothing
                return;
            }
			if(Tail.X == Head.X)
			{
				// move U or D
				if(Head.Y > Tail.Y)
				{
					for(int y = Tail.Y;y < Head.Y;y++)
					{
						TailPoints.Add(new RopePoint(Tail.X, y));
					}
					Tail.Y = Head.Y - 1;
				}
				else
				{
                    for (int y = Tail.Y; y > Head.Y; y--)
                    {
                        TailPoints.Add(new RopePoint(Tail.X, y));
                    }
                    Tail.Y = Head.Y + 1;
                }
                return;
            }

			if(Tail.Y == Head.Y)
			{
                // move L or R
                if (Head.X > Tail.Y)
                {
                    for (int x = Tail.X; x < Head.X; x++)
                    {
                        TailPoints.Add(new RopePoint(x, Tail.Y));
                    }
                    Tail.X = Head.X - 1;
                }
                else
                {
                    for (int x = Tail.X; x > Head.X; x--)
                    {
                        TailPoints.Add(new RopePoint(x, Tail.Y));
                    }
                    Tail.X = Head.X + 1;
                }
                return;
            }

			// not on same row or col => diagonal jump
            // do diagonal jump and then call Move again            
            if(Head.Y > Tail.Y)
            {
                Tail.Y++;
            }
            if(Head.X > Tail.X)
            {
                Tail.X++;
            }
            if(Head.Y < Tail.Y)
            {
                Tail.Y--;
            }
            if(Head.X  < Tail.X)
            {
                Tail.X--;
            }
            TailPoints.Add(new RopePoint(Tail.X, Tail.Y));
            MoveTail();
        }

		public List<RopePoint> TailPoints { get; set; }
	}

}