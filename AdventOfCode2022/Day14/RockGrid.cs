using System;
namespace AdventOfCode2022.Day14
{
	public class RockGrid
	{
		public RockGrid(IEnumerable<string> input)
		{
			RockLines = new List<RockLine>();
			foreach(var line in input)
			{
				var rockLines = line.Split(" -> ");
				var numOfLines = rockLines.Length - 1;
				for(int i=0;i<numOfLines;i++)
				{
					var rl = new RockLine(new RockPoint(rockLines[i]), new RockPoint(rockLines[i + 1]));
					RockLines.Add(rl);
				}
			}

			CalculateEdges();
			Rocks = new HashSet<RockPoint>();

            foreach (var line in RockLines)
			{
				foreach(var p in line.PointsCovered)
				{
					Rocks.Add(p);
				}
			}

			Sands = new HashSet<RockPoint>();
		}

		public List<RockLine> RockLines { get; set; }
		public RockPoint LeftEdge { get; set; }
		public RockPoint RightEdge { get; set; }

		public HashSet<RockPoint> Sands { get; set; } 
		public HashSet<RockPoint> Rocks { get; set; }

        /// <summary>
        /// Return true if sand drops over edge
        /// </summary>
        /// <returns></returns>
        public bool DropSand()
		{
			// start
			var sand = new RockPoint() { X = 500,Y = 0};
			while(!SandIsAtRest(sand) && !IsOverEdge(sand))
			{
				var nextBlock = new RockPoint(sand.X, sand.Y+1);
				var diagLeftBlock = new RockPoint(sand.X-1, sand.Y + 1);
                var diagRightBlock = new RockPoint(sand.X + 1, sand.Y + 1);

                // if you hit sand or rock move diagonal (X/Y)
                if (Sands.Contains(nextBlock) || Rocks.Contains(nextBlock))
				{
					// check left diag
					if(Sands.Contains(diagLeftBlock) || Rocks.Contains(diagLeftBlock))
					{
						sand = diagRightBlock;
					}
					else
					{
						sand = diagLeftBlock;
					}

				}
				else
				{
                    // else move only down (Y)
                    sand = nextBlock;
                }
			}
			Sands.Add(sand);
			return IsOverEdge(sand);
		}

		private bool SandIsAtRest(RockPoint sand)
		{
            var nextBlock = new RockPoint(sand.X, sand.Y + 1);
            var diagLeftBlock = new RockPoint(sand.X - 1, sand.Y + 1);
            var diagRightBlock = new RockPoint(sand.X + 1, sand.Y + 1);


			return (Rocks.Any(b => b.Equals(nextBlock)) || Sands.Any(b => b.Equals(nextBlock)))  // next is blocked
                && (Rocks.Any(b => b.Equals(diagLeftBlock)) || Sands.Any(b => b.Equals(diagLeftBlock)))  // diag left is blocked
                && (Rocks.Any(b => b.Equals(diagRightBlock)) || Sands.Any(b => b.Equals(diagRightBlock))); // diag right is blocked
        }



		private bool IsOverEdge(RockPoint point)
		{
			return (point.X < LeftEdge.X && point.Y > LeftEdge.Y)
				|| (point.X > RightEdge.X && point.Y > RightEdge.Y);
		}

		private void CalculateEdges()
		{
			// left
			LeftEdge = RockLines.Select(l => l.LeftEdge).OrderBy(p => p.X).First();

            // right
            RightEdge = RockLines.Select(l => l.RightEdge).OrderByDescending(p => p.X).First();
        }
	}
}

