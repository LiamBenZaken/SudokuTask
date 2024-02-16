using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    public class FileInputReader : IInputReader
    {
        private string fileName;

        public FileInputReader(string fileName)
        {
            this.fileName = fileName; 
        }
        public string ReadInput()
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch(Exception ex) 
            {
                throw new IOException($"Error reading from file: {ex.Message}");
            }
        }
    }
}
