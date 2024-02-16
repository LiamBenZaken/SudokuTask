using System;
using System.Collections.Generic;

namespace sudoku.SudokuBoardParts
{
    public interface ISudokuBoard
    {
        int boardSize { get;}
        List<Cell> emptyCells { get;}

        Cell GetCell(int row, int col);

        void SetCell(int row, int col, Cell cell);

        HashSet<Cell> RemoveOptions(int row, int col);

        int GetNumber(int row, int col);

        void SetNumber(int row, int col, int value);

        Boolean IsValidBoard(string input);

    }
}
