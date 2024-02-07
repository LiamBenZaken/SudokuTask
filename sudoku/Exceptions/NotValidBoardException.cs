using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    public class NotValidBoardException : Exception
    {
        public NotValidBoardException(int num): base($"Cannot build sudoku board with this amount of numbers:{num}") { }
    }
}
