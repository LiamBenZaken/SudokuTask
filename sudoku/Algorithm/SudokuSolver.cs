﻿using sudoku.Exceptions;
using sudoku.InputAndOutput;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sudoku.Algorithm
{
    /// <summary>
    /// Provides methods to solve Sudoku boards.
    /// </summary>
    public class SudokuSolver
    {
        /// <summary>
        /// Solves the Sudoku board using a backtracking algorithm.
        /// </summary>
        /// <param name="board">The Sudoku board to be solved.</param>
        /// <returns>The solved Sudoku board.</returns>
        /// <exception cref="NotSolvableBoardException">Thrown if the Sudoku board is not solvable.</exception>
        public static ISudokuBoard SolveSudoku(ISudokuBoard board)
        {
            Cell min = FindCellWithLeastOptionsFirstTime(board);
            bool flag = IsOnlyOneSolve(board);
            
            ISudokuBoard SolvedBoard = Solve(board, min,flag);
            if (SolvedBoard == null)
                throw new NotSolvableBoardException();
            return SolvedBoard;
        }
        private static ISudokuBoard Solve(ISudokuBoard board, Cell cell,bool flag)
        {
            Cell CellWithLeastOptions;
            if (!flag)
                CellWithLeastOptions = FindCellWithLeastOptions(cell);
            else
                CellWithLeastOptions = FindCellWithLeastOptionsFirstTime(board);

            int row = CellWithLeastOptions.row;
            int col = CellWithLeastOptions.col;
            if (row == -1 || col == -1)
                return board;

            board.emptyCells.Remove(CellWithLeastOptions);
            foreach (int option in board.GetCell(row, col).options)
            {
                board.SetNumber(row, col, option);
                HashSet<Cell> affectedCells = board.RemoveOptions(row, col);

                ISudokuBoard result = Solve(board, board.GetCell(row, col),flag);
                if (result != null && IsSolved(board.emptyCells))
                    return board;

                foreach (Cell affectedCell in affectedCells)
                    affectedCell.AddOption(option);
            }
            board.emptyCells.Add(CellWithLeastOptions);
            board.SetNumber(row, col, 0);
            return null;
        }

        // <summary>
        /// Finds the cell with the least number of options.
        /// </summary>
        /// <param name="min">The cell to start with.</param>
        /// <returns>The cell with the least number of options.</returns>
        public static Cell FindCellWithLeastOptions(Cell min)
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

        /// <summary>
        /// Finds the first cell with the least number of options.
        /// </summary>
        /// <param name="board">The Sudoku board.</param>
        /// <returns>The first cell with the least number of options.</returns>
        public static Cell FindCellWithLeastOptionsFirstTime(ISudokuBoard board)
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

        /// <summary>
        /// Checks if the Sudoku board is solved.
        /// </summary>
        /// <param name="emptyCells">The list of empty cells in the board.</param>
        /// <returns>True if the board is solved, otherwise false.</returns>
        public static bool IsSolved(List<Cell> emptyCells)
        {
            return emptyCells.Count == 0;
        }

        /// <summary>
        /// Determines whether the Sudoku board has only one possible solution.
        /// </summary>
        /// <param name="board">The Sudoku board to check.</param>
        /// <returns>True if the Sudoku board has only one possible solution; otherwise, false.</returns>
        public static bool IsOnlyOneSolve(ISudokuBoard board)
        {
            HashSet<int> uniqe = new HashSet<int>();
            for (int i = 0; i < board.boardSize; i++)
                for (int j = 0; j < board.boardSize; j++)
                    if (board.GetCell(i, j).number != 0)
                        uniqe.Add(board.GetCell(i, j).number);
            return uniqe.Count >= board.boardSize-1;
        }
    }
}

