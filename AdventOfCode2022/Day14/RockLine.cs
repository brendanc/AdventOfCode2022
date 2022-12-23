using System;
namespace AdventOfCode2022.Day14
{
	public class RockLine
	{
		public RockLine(RockPoint start, RockPoint end)
		{
			Start = start;
			End = end;
			CalculateCoverage();

        }

		public RockPoint Start { get; set; }
		public RockPoint End { get; set; }
		public RockPoint LeftEdge { get; set; }
		public RockPoint RightEdge { get; set; }

		public List<RockPoint> PointsCovered { get; set; }

		private void CalculateCoverage()
		{
			PointsCovered = new List<RockPoint>();
			PointsCovered.Add(Start);
			PointsCovered.Add(End);

			// which is equal x or y
			if(Start.X == End.X)
			{
				// we going up or down?
				if(Start.Y < End.Y)
				{
					for(var y = Start.Y+1;y< End.Y;y++)
					{
						PointsCovered.Add(new RockPoint() { X = Start.X, Y = y });
					}
				}
				else
				{
                    for (var y = Start.Y-1; y > End.Y; y--)
                    {
                        PointsCovered.Add(new RockPoint() { X = Start.X, Y = y });
                    }
                }

				LeftEdge = new RockPoint() { X = Start.X, Y = PointsCovered.Max(p => p.Y) };
				RightEdge = new RockPoint() { X = Start.X, Y = PointsCovered.Max(p => p.Y) };
            }

			if(Start.Y == End.Y)
			{
				if(Start.X < End.X)
				{
					for(var x = Start.X+1;x < End.X;x++)
					{
						PointsCovered.Add(new RockPoint() { X = x, Y = Start.Y });
					}
				}
				else
				{
                    for (var x = Start.X-1; x > End.X; x--)
                    {
                        PointsCovered.Add(new RockPoint() { X = x, Y = Start.Y });
                    }
                }

                LeftEdge = new RockPoint() { X = PointsCovered.Min(p => p.X), Y = Start.Y };
                RightEdge = new RockPoint() { X = PointsCovered.Max(p => p.X), Y = End.Y };

            }
		}
	}
}

