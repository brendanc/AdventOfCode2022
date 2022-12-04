using System;
namespace AdventOfCode2022.Day4
{
	public class ElfPair
	{
		private List<int> fullArray;
		public ElfPair(string inputString)
		{
			var numbers = inputString.Split('-');
			MinNumber = Convert.ToInt32(numbers[0]);
			MaxNumber = Convert.ToInt32(numbers[1]);
        }

		public int MinNumber { get; set; }
		public int MaxNumber { get; set; }
		public int Range => MaxNumber - MinNumber;

		public IEnumerable<int> FullCollection
		{
			get
			{
				if(fullArray == null)
				{
					fullArray = new List<int>();
					for(int i = MinNumber;i <=MaxNumber;i++)
					{
						fullArray.Add(i);
					}
				}
				return fullArray;
			}
		}

    }
}

