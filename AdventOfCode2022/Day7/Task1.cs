using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day7
{
	public class Task1: AdventOfCodeTaskBase
	{
        public override void Run()
        {
            var input = this.GetInput();

            var root = new DirectoryParser().Parse(input);
            var max = 100000;
            var answer = CalcLimitedFolderSizes(root, max);
            Console.WriteLine("Sum total of dirs with at most 100000 = " + answer);
        }

        private Int32 CalcLimitedFolderSizes(DeviceFolder folder, int limit)
        {
            var total = 0;
            if(folder.FolderName != "/")
            {
                if(folder.FolderSize < limit)
                {
                    total += folder.FolderSize;
                }
            }
           foreach(var f in folder.Folders)
            {
                total += CalcLimitedFolderSizes(f, limit);
            }
            return total;
        }
    }
}

