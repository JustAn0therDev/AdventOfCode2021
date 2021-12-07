using System;
using System.IO;

namespace AdventOfCode2021
{
    public abstract class AbstractDay
    {
        public virtual long PartOne()
        {
            throw new NotImplementedException("This class does not implement a part one solution.");
        }

        public virtual long PartTwo()
        {
            throw new NotImplementedException("This class does not implement a part two solution.");
        }

        /// <summary>
        /// This method reads a file given as input (in the path specified) and returns its content split by '\n'.
        /// </summary>
        /// <param name="inputPath">The path of the input file.</param>
        /// <returns>An array of strings, each containing the contents of a line of the file.</returns>
        /// <exception cref="NotImplementedException">Throws this exception if not implemented</exception>
        /// <exception cref="FileNotFoundException">
        /// Throws this exception if the file does not exist at the specified path (you might have forgotten to set the file to
        /// be copied to output when compiling in the AdventOfCode2021.csproj file).
        /// </exception>
        protected static string[] GetInput(string inputPath, string separator = null) => File.ReadAllText(inputPath).Split(string.IsNullOrEmpty(separator) ? "\r\n" : separator);
    }
}