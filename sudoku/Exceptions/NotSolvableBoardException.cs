using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Exceptions
{
    public class NotSolvableBoardException : Exception
    {
        public NotSolvableBoardException() : base("Connot solve this board , it unsolvable!") { }
    }
}
