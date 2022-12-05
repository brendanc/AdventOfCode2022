using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2022.Day5
{
	public class CrateStacks
	{
		public CrateStacks(IEnumerable<string> stackInput)
		{
			PopulateStacks(stackInput);
		}

		public List<LinkedList<string>> TheStacks { get; set; }

		private void PopulateStacks(IEnumerable<string> stackInput)
		{
			var stackData = new List<string>();
			var numberLine = "";
			foreach(var line in stackInput)
			{
				stackData.Add(line);
				// find the row starting with #1 that is the end of the stack input
				if(line.TrimStart().StartsWith("1"))
				{
					numberLine = line;
					// take the number line out
					stackData.RemoveAt(stackData.Count() - 1);
					break;
				}
			}

			var numberOfStacks = Convert.ToInt32(numberLine.Trim().Split(' ').Last());
			TheStacks = new List<LinkedList<string>>();
			for(var i=0;i<numberOfStacks;i++)
			{
				TheStacks.Add(new LinkedList<string>());
			}

			// flip that data so bottom is first
			stackData.Reverse();
			foreach(var row in stackData)
			{
                var blocks = ChunkString(row, 4);
				for(var i=0;i<blocks.Count();i++)
				{
					if (!string.IsNullOrEmpty(blocks.ElementAt(i).Trim()))
					{
						TheStacks[i].AddLast(blocks.ElementAt(i));
					}
                }
            }

        }

		private IEnumerable<string> ChunkString(string str, int chunkSize)
        {
            for (int i = 0; i < str.Length; i += chunkSize)
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
        }


		public string GetLastItemsInStacks()
		{
            // output
            var topOfStacks = "";
            foreach (var s in TheStacks)
            {
                topOfStacks += GetLastItemInStack(s);
            }
			return topOfStacks;
        }


        private string GetLastItemInStack(IEnumerable<string> stack)
        {
            return stack.Last().Replace("[", "").Replace("]", "").Trim();
        }
    }
}

