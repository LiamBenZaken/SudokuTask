using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    /// <summary>
    /// Exception thrown when attempting to create an invalid Sudoku board.
    /// </summary>
    public class InvalidBoardException : SudokuException
    {
        /// <summary>
        /// Initializes a new instance of the InvalidBoardException class with a default error message.
        /// </summary>
        public InvalidBoardException() : base($"Cannot build sudoku board , this board is not Valid!") { }
    }
}
