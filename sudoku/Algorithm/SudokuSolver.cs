using sudoku.InputAndOutput;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Algorithm
{
    public class SudokuSolver
    {
        public static ISudokuBoard Solve(ISudokuBoard board)
        {

            Cell CellWithLeastOptions = FindCellWithLeastOptions(board);
            int row = CellWithLeastOptions.row;
            int col = CellWithLeastOptions.col;
            if (row == -1 || col == -1)
                return board;

            board.emptyCells.Remove(CellWithLeastOptions);
            foreach (int option in board.GetCell(row, col).options)
            {
                board.SetNumber(row, col, option);
                HashSet<Cell>affectedCells = board.RemoveOptions(row, col);

                ISudokuBoard result = Solve(board);
                if (result != null && IsSolved(board.emptyCells))
                    return board;

                foreach (Cell affectedCell in affectedCells)
                    affectedCell.AddOption(option);
            }
            board.emptyCells.Add(CellWithLeastOptions);
            board.SetNumber(row, col, 0);
            return null;
        }


        private static Cell FindCellWithLeastOptions(ISudokuBoard board)
        {
            int minOptions = int.MaxValue;
            Cell minCell = new Cell(-1, -1, -1);

            foreach (Cell cell in board.emptyCells)
                if (cell.options.Count < minOptions)
                {
                    minOptions = cell.options.Count;
                    minCell = cell;
                }
            return minCell;
        }

        private static bool IsSolved(List<Cell> emptyCells)
        {
            return emptyCells.Count == 0;
        }

        private static HashSet<Cell> ApplyNakedSingle(ISudokuBoard board,ref int flag)
        {
            HashSet<Cell> affectedCells = new HashSet<Cell>();
            foreach (Cell cell in board.emptyCells)
                if (cell.options.Count == 1)
                {
                    board.SetNumber(cell.row, cell.col, cell.options.First());
                    affectedCells = board.RemoveOptions(cell.row, cell.col);
                    board.emptyCells.Remove(cell);
                    flag = 1;
                }
            return affectedCells;
        }
    }
}

