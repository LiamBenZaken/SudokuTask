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
        private string _fileName;

        public FileInputReader(string fileName)
        {
            this._fileName = fileName; 
        }
        public string ReadInput()
        {
            try
            {
                return File.ReadAllText(_fileName);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return null;
            }
        }
    }
}
