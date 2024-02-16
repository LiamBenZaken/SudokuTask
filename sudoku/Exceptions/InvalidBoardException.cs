using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    public class InvalidBoardException : SudokuException
    {
        public InvalidBoardException(): base($"Cannot build sudoku board , this board is not Valid!") { }
    }
}
