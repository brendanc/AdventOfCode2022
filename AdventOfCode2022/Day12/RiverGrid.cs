using System;
namespace AdventOfCode2022.Day12
{
	public class RiverGrid
	{

		public RiverGrid(IEnumerable<string> input)
		{
			Grid = new List<string>();
			foreach(var line in input)
			{
				Grid.Add(line);
			}
		}

		public List<string> Grid { get; set; }

		public GridPosition FindStart()
		{
			return FindByValue('S').First();
		}

        public GridPosition FindEnd()
        {
			return FindByValue('E').First();
        }

		public List<GridPosition> FindPossibleStarts()
		{
			return FindByValue('a');
		}

        private List<GridPosition> FindByValue(char value)
		{
			var positions = new List<GridPosition>();
			for (var i = 0; i < Grid.Count(); i++)
			{
				var line = Grid[i];
				if (!line.Contains(value))
				{
					continue;
				}
				for (var p = 0; p < line.Length - 1; p++)
				{
					var element = line[p];
					if (element == value)
					{
						positions.Add(new GridPosition()
						{
							X = p,
							Y = i,
							Value = value
						});
					}
				}
            }
			return positions;
        }


		public List<GridPosition> FindAdjacentPositions(GridPosition position)
		{
			var adjacents = new List<GridPosition>();
			var possible = FindPossibleAdjacents(position.Pos);

			foreach(var p in possible)
			{
				var val = Grid.ElementAt(p.Item2).ElementAt(p.Item1);
				var gp = new GridPosition() { X = p.Item1, Y = p.Item2, Value=val };
				adjacents.Add(gp);
			}

			return adjacents;
		}

		private IEnumerable<Tuple<int,int>> FindPossibleAdjacents(Tuple<int,int> position)
		{
			var maxX = Grid.First().Length-1;
			var maxY = Grid.Count()-1;
			var minX = 0;
			var minY = 0;

			var up = new Tuple<int, int>(position.Item1, position.Item2 -1 );
			var down = new Tuple<int, int>(position.Item1, position.Item2 + 1);
			var left = new Tuple<int, int>(position.Item1 - 1, position.Item2);
			var right = new Tuple<int, int>(position.Item1 + 1, position.Item2);

			var list = new List<Tuple<int, int>> { up, down, left, right };

			return list.Where(x => x.Item1 >= 0 && x.Item1 <= maxX && x.Item2 >= 0 && x.Item2 <= maxY);
        }

	}
}

