using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class DeviceFile
    {
        public DeviceFile(string name, int size)
        {
            this.FileName = name;
            this.FileSize = size;
        }
        public string FileName { get; set; }
        public int FileSize { get; set; }
    }
}
