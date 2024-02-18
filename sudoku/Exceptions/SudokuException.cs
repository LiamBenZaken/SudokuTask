using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    /// <summary>
    /// An abstract base class for exceptions related to Sudoku boards.
    /// </summary>
    public abstract class SudokuException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SudokuException class with the specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public SudokuException(string message) : base(message) { }
    }
}
