using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    /// <summary>
    /// Exception thrown when a Sudoku board is found to be unsolvable.
    /// </summary>
    public class NotSolvableBoardException : SudokuException
    {
        /// <summary>
        /// Initializes a new instance of the NotSolvableBoardException class with a default error message.
        /// </summary>
        public NotSolvableBoardException() : base("Connot solve this board , it unsolvable!") { }
    }
}
