using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    /// <summary>
    /// Represents an input reader that reads Sudoku board input from the console.
    /// </summary>
    public class ConsoleInputReader : IInputReader
    {
        /// <summary>
        /// Reads a Sudoku board input from the console.
        /// </summary>
        /// <returns>The Sudoku board input entered by the user.</returns>
        public string ReadInput()
        {
            Console.WriteLine("enter the sudoku board:");
            return Console.ReadLine();
        }
    }
}
