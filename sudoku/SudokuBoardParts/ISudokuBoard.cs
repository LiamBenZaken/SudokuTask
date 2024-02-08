using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.SudokuBoardParts
{
    public interface ISudokuBoard
    {
        int boardSize { get;}
        Cell GetCell(int row, int col);
        Boolean IsValidBoard(int boardSize,string input);
    }
}
