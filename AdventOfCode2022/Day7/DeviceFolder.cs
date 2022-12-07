using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class DeviceFolder
    {
        public DeviceFolder(string name)
        {
            this.FolderName = name;
            this.Files = new List<DeviceFile>();
            this.Folders = new List<DeviceFolder>();
        }

        public string FolderName { get; set; }
        public List<DeviceFolder> Folders { get; set; }
        public List<DeviceFile> Files { get; set; }
        public int FolderSize
        {
            get
            {
                var filesSizes =  Files.Sum(f => f.FileSize);
                var folderSizes = Folders.Sum(f => f.FolderSize);
                return filesSizes + folderSizes;
            }
        }
        public DeviceFolder FindSubFolder(string name)
        {
            return this.Folders.First(f => f.FolderName == name);
        }
        public DeviceFolder ParentFolder { get; set; }

        public string FullyQualifiedName
        {
            get
            {
                if(FolderName == "/")
                {
                    return "/";
                }
                var fqn = FolderName;
                var parent = this.ParentFolder;
                while(parent != null)
                {
                    fqn += parent.FolderName + "->" + fqn;
                    if(parent.FolderName == "/")
                    {
                        return "/" + fqn;
                    }
                    parent = parent.ParentFolder;
                }
                return "unknown";
            }
        }
    }
}
