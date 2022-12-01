using System;
using System.Reflection;

namespace AdventOfCode2022.Shared
{
	public class InputReader
	{
        public static string ReadInput(string inputFileName)
        {
            var resourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(inputFileName);

            if (resourceStream == null)
            {
                throw new ArgumentNullException(nameof(inputFileName), $"{inputFileName} file stream cannot be null");
            }

            using (resourceStream)
            using (var streamReader = new StreamReader(resourceStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}

