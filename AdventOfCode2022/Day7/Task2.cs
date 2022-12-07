using System;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day7
{
	public class Task2 : AdventOfCodeTaskBase
	{
        private Dictionary<string, int> foldersAndSizes;

        public override void Run()
        {
            var input = this.GetInput();
            var root = new DirectoryParser().Parse(input);
            foldersAndSizes = new Dictionary<string, int>();
            CalcFolderSizes(root);


            var total = 70000000;
            var free = total - foldersAndSizes["/"];
            var need = 30000000 - free;


            var result = foldersAndSizes.Where(f => f.Value > need).OrderBy(f => f.Value).ToList();
            var answer = result.First().Value;
            Console.WriteLine("Min director value is" + answer);
        }

        private void CalcFolderSizes(DeviceFolder folder)
        {
            var total = folder.FolderSize;
            foldersAndSizes.Add(folder.FullyQualifiedName, total);               
            
            foreach (var f in folder.Folders)
            {
                 CalcFolderSizes(f);
            }
        }
    }
}


