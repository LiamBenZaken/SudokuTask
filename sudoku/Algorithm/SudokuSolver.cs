using sudoku.Exceptions;
using sudoku.InputAndOutput;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Algorithm
{
    public class SudokuSolver
    {
        public static ISudokuBoard SolveSudoku(ISudokuBoard board)
        {
            Cell min = FindCellWithLeastOptionsFirstTime(board);

            ISudokuBoard SolvedBoard = Solve(board,min);
            if (SolvedBoard == null)
                throw new NotSolvableBoardException();
            return SolvedBoard;
        }
        private static ISudokuBoard Solve(ISudokuBoard board,Cell cell)
        {

            Cell CellWithLeastOptions = FindCellWithLeastOptions(cell);
            int row = CellWithLeastOptions.row;
            int col = CellWithLeastOptions.col;
            if (row == -1 || col == -1)
                return board;

            board.emptyCells.Remove(CellWithLeastOptions);
            foreach (int option in board.GetCell(row, col).options)
            {
                board.SetNumber(row, col, option);
                HashSet<Cell>affectedCells = board.RemoveOptions(row, col);

                ISudokuBoard result = Solve(board,board.GetCell(row, col));
                if (result != null && IsSolved(board.emptyCells))
                    return board;

                foreach (Cell affectedCell in affectedCells)
                    affectedCell.AddOption(option);
            }
            board.emptyCells.Add(CellWithLeastOptions);
            board.SetNumber(row, col, 0);
            return null;
        }


        private static Cell FindCellWithLeastOptions(Cell min)
        {
            int minOptions = int.MaxValue;
            Cell minCell = new Cell(-1, -1, -1);

            foreach (Cell cell in min.connected)
                if (cell.number == 0 && cell.options.Count < minOptions)
                {
                    minOptions = cell.options.Count;
                    minCell = cell;
                }
            return minCell;
        }

        private static Cell FindCellWithLeastOptionsFirstTime(ISudokuBoard board)
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
    }
}

