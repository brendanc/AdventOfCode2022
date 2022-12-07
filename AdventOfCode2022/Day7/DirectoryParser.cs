using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class DirectoryParser
    {
        public DeviceFolder Parse(IEnumerable<string> input)
        {
            var root = new DeviceFolder("/");
            var currentDir = root;
            foreach (var line in input)
            {
                if (line == "$ ls")
                {
                    continue;
                }

                if (line.StartsWith("$ cd") && line.Contains("..") == false)
                {
                    if(line.EndsWith("/"))
                    {
                        // handle root
                        currentDir = root;
                        continue;
                    }
                    // we are in a folder 
                    var parent = currentDir;
                    currentDir = currentDir.FindSubFolder(ParseName(line));
                    currentDir.ParentFolder = parent;
                    continue;
                }

                if (line == "$ cd ..")
                {
                    currentDir = currentDir.ParentFolder;
                    continue;
                }

                if (line.StartsWith("dir"))
                {
                    // found a directory add to current directory
                    var dir = new DeviceFolder(ParseName(line));
                    currentDir.Folders.Add(dir);
                    continue;
                }

                // if we get here it's a file
                var splits = line.Split(' ');
                currentDir.Files.Add(new DeviceFile(splits[1], Convert.ToInt32(splits[0])));
            }
            return root;
        }


        private string ParseName(string input)
        {
            return input.Substring(input.LastIndexOf(" "), input.Length - input.LastIndexOf(" "));
        }
    }
}
