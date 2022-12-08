using System;
namespace AdventOfCode2022.Day8
{
	public class TreeGrid
	{
		public TreeGrid(IEnumerable<string> input)
		{
            Grid = input;
        }

        public IEnumerable<string> Grid { get; }

        public string FindRow(int rowIndex)
        {
            return Grid.ElementAt(rowIndex);
        }

        public string FindColumn(int columnIndex)
        {
            var column = "";
            foreach(var line in Grid)
            {
                column += line.ElementAt(columnIndex);
            }
            return column;
        }

        public bool TreeIsVisible(int rowIndex,int columnIndex)
        {
            if(rowIndex == 0 || columnIndex == 0
                || rowIndex == this.FindColumn(0).Length-1 || columnIndex == this.FindRow(0).Length-1)
            {
                return true;
            }

            var value = Convert.ToInt32(Grid.ElementAt(rowIndex).ElementAt(columnIndex).ToString());
            var row = FindRow(rowIndex);
            var col = FindColumn(columnIndex);

            var left = row.Substring(0, columnIndex).Select(c => Convert.ToInt32(c.ToString()));
            var right = row.TakeLast(row.Length - columnIndex - 1).Select(c => Convert.ToInt32(c.ToString()));

            var up = col.Substring(0, rowIndex).Select(c => Convert.ToInt32(c.ToString()));
            var down = col.TakeLast(col.Length - rowIndex - 1).Select(c => Convert.ToInt32(c.ToString()));


            return IsMaxInSegment(value, right) || IsMaxInSegment(value, left)
                || IsMaxInSegment(value, up) || IsMaxInSegment(value, down);

        }

        private bool IsMaxInSegment(int value, IEnumerable<int>segment)
        {
            var numbers = new List<int>();
            numbers.AddRange(segment);
            numbers.Add(value);
            return numbers.Max() == value && numbers.Count(n => n == value) == 1;
        }

        public int GetScenicScore(int rowIndex, int columnIndex)
        {

            if (rowIndex == 0 || columnIndex == 0
                || rowIndex == this.FindColumn(0).Length - 1 || columnIndex == this.FindRow(0).Length - 1)
            {
                return 0;
            }

            var value = Convert.ToInt32(Grid.ElementAt(rowIndex).ElementAt(columnIndex).ToString());
            var row = FindRow(rowIndex);
            var col = FindColumn(columnIndex);

            var left = row.Substring(0, columnIndex).Select(c => Convert.ToInt32(c.ToString()));
            var right = row.TakeLast(row.Length - columnIndex - 1).Select(c => Convert.ToInt32(c.ToString()));

            var up = col.Substring(0, rowIndex).Select(c => Convert.ToInt32(c.ToString()));
            var down = col.TakeLast(col.Length - rowIndex - 1).Select(c => Convert.ToInt32(c.ToString()));

            var leftScore = CalcDirectinoalScore(value, left.Reverse());
            var rightScore = CalcDirectinoalScore(value, right);
            var upScore = CalcDirectinoalScore(value, up.Reverse());
            var downScore = CalcDirectinoalScore(value, down);

            return leftScore * rightScore * upScore * downScore;

        }

        private int CalcDirectinoalScore(int value, IEnumerable<int> segment)
        {
            var score = 0;
            foreach(var tree in segment)
            {
                score++;
                if (tree >= value)
                {
                    return score;
                }
            }
            return score;
        }
    }
}

