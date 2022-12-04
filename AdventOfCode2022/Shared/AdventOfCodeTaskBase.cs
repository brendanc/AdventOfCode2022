using System;
namespace AdventOfCode2022.Shared
{
    public abstract class AdventOfCodeTaskBase : IAdventOfCodeTask
    {
        public abstract void Run();

        protected virtual string InputFileName
        {
            get
            {
                var t = this.GetType().ToString();
                var last = t.LastIndexOf('.');
                return t.Substring(0, last) + ".Input1.txt";
            }
        }

        protected IEnumerable<string> GetInput()
        {
            return InputReader.ReadInputAsLines(InputFileName);
        }
    }
}


