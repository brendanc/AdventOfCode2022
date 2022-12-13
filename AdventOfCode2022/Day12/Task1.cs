using AdventOfCode2022.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day12
{
    public class Task1 : AdventOfCodeTaskBase
    {
        public const int MinTravelValue = 97;
        public const int EndValue = 69;

        public HashSet<GridPosition> traveledPositions;

        public RiverGrid grid;

        public override void Run()
        {
//            var input = @"Sabqponm
//abcryxxl
//accszExk
//acctuvwj
//abdefghi".Trim().Split('\n');

            var input = GetInput();


            grid = new RiverGrid(input);
            var start = grid.FindStart();
            traveledPositions = new HashSet<GridPosition>();
            var previous = new Dictionary<GridPosition, GridPosition>();
            bool atEnd = false;

            var queue = new Queue<GridPosition>();
            queue.Enqueue(start);


            while (!atEnd)
            {
                var pos = queue.Dequeue();
                var newPositions = GetValidPaths(pos);           
                foreach (var n in newPositions)
                {
                    if (!traveledPositions.Contains(n))
                    {
                        traveledPositions.Add(n);
                        previous[n] = pos;
                        queue.Enqueue(n);
                    }
                }           
                atEnd = traveledPositions.Any(p => p.IsEnd);
            }

            var end = grid.FindEnd();
            var shortestHops = CalculateShortestPath(previous,start,end);
            Console.WriteLine("It took {0} steps to find the end", traveledPositions.Where(p => p.IsEnd == false && p.IsStart == false).Distinct().Count());
        }


        public List<GridPosition> GetValidPaths(GridPosition start)
        {
            var positions = grid.FindAdjacentPositions(start);
            var result = positions.Where(p => p.IntValue <= Math.Max(start.IntValue,MinTravelValue) + 1).ToList();
            return result.Distinct().ToList();
        }

        public int CalculateShortestPath(Dictionary<GridPosition,GridPosition> history, GridPosition start,GridPosition end)
        {
            var path = new List<GridPosition>();

            var current = end;
            while (!current.Equals(start))
            {
                path.Add(current);
                current = history[current];
            };
           // path.Add(start);
            return path.Count();
        }
    }
}
