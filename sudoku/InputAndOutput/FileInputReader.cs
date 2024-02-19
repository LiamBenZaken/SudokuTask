using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    /// <summary>
    /// Represents an input reader that reads Sudoku board input from a file.
    /// </summary>
    public class FileInputReader : IInputReader
    {
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the FileInputReader class with the specified file name.
        /// </summary>
        /// <param name="fileName">The path to the file containing the Sudoku board input.</param>
        public FileInputReader(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Reads the Sudoku board input from the specified file.
        /// </summary>
        /// <returns>The Sudoku board input read from the file.</returns>
        /// <exception cref="IOException">Thrown if an error occurs while reading from the file.</exception>
        public string ReadInput()
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                throw new IOException($"Error reading from file: {ex.Message}");
            }
        }
    }
}
