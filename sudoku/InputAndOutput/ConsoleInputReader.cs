using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadInput()
        {
            try
            {
                Console.WriteLine("enter the sudoku board:");
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading input: {ex.Message}");
                return null;
            }
        }
    }
}
