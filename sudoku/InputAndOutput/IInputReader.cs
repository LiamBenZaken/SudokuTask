using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    /// <summary>
    /// Represents an interface for reading Sudoku board input.
    /// </summary>
    public interface IInputReader
    {
        string ReadInput();
    }
}
