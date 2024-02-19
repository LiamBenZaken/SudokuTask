using sudoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace sudoku.SudokuBoardParts
{
    /// <summary>
    /// Represents a Sudoku board implemented using a matrix.
    /// </summary>
    public class MatrixBoard : ISudokuBoard
    {
        public int boardSize { get; private set; }
        private Cell[,] board;
        public List<Cell> emptyCells { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MatrixBoard class with the provided input string.
        /// </summary>
        /// <param name="input">The input string representing the Sudoku board.</param>
        /// <exception cref="InvalidBoardException">Thrown if the input string is not a valid Sudoku board.</exception>
        public MatrixBoard(string input)
        {
            emptyCells = new List<Cell>();
            boardSize = (int)Math.Sqrt(input.Length);

            if (!IsValidBoard(input))
                throw new InvalidBoardException();

            board = new Cell[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j] = new Cell(i, j, (int)(input[i * boardSize + j]) - 48);
            InitCellsOptions();
        }

        /// <summary>
        /// Initializes the options for empty cells and the connections for all cells.
        /// </summary>
        private void InitCellsOptions()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    if (board[i, j].number == 0)
                    {
                        for (int k = 1; k <= boardSize; k++)
                            board[i, j].AddOption(k);
                        emptyCells.Add(board[i, j]);
                    }

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                {
                    InitConnectionCells(board[i, j], i, j);
                    if (board[i, j].number != 0)
                        RemoveOptions(i, j);
                }
        }

        /// <summary>
        /// Removes the options for a cell based on the current number in its row, column, and box.
        /// </summary>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="col">The column index of the cell.</param>
        /// <returns>A hash set of cells affected by remove function.</returns>
        public HashSet<Cell> RemoveOptions(int row, int col)
        {
            HashSet<Cell> res = new HashSet<Cell>();
            Cell currentCell = board[row, col];

            foreach (Cell cell in currentCell.connected)
                if (cell.number == 0)
                    if (cell.RemoveOption(currentCell.number))
                        res.Add(cell);
            return res;
        }

        /// <summary>
        /// Initializes the connected cells for a given cell based on its row, column, and box.
        /// </summary>
        /// <param name="cell">The cell for which to initialize connected cells.</param>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="col">The column index of the cell.</param>
        /// <exception cref="InvalidBoardException">Thrown if there is same number for 2 cells that located in the same box,row or col.</exception>
        public void InitConnectionCells(Cell cell, int row, int col)
        {
            for (int j = 0; j < boardSize; j++)
                if (j != col)
                {
                    if (cell.number != 0 && cell.number == board[row, j].number)
                        throw new InvalidBoardException();
                    cell.connected.Add(board[row, j]);
                }

            for (int i = 0; i < boardSize; i++)
                if (i != row)
                {
                    if (cell.number != 0 && cell.number == board[i, col].number)
                        throw new InvalidBoardException();
                    cell.connected.Add(board[i, col]);
                }

            int boxSize = (int)Math.Sqrt(boardSize);
            int boxStartRow = (row / boxSize) * boxSize;
            int boxStartCol = (col / boxSize) * boxSize;
            for (int i = boxStartRow; i < boxStartRow + boxSize; i++)
                for (int j = boxStartCol; j < boxStartCol + boxSize; j++)
                {
                    if (i != row || j != col)
                    {
                        if (cell.number != 0 && cell.number == board[i, j].number)
                            throw new InvalidBoardException();
                        cell.connected.Add(board[i, j]);
                    }
                }
        }

        /// <summary>
        /// Determines whether the input string represents a valid Sudoku board.
        /// </summary>
        /// <param name="input">The input string representing the Sudoku board.</param>
        /// <returns>True if the input string represents a valid Sudoku board; otherwise, false.</returns>
        public bool IsValidBoard(string input)
        {
            if (input == null || input.Length == 0)
                return false;
            if (boardSize * boardSize != input.Length)
                return false;

            int[] numCounts = new int[boardSize + 1];
            for (int i = 0; i < input.Length; i++)
            {
                int num = (int)(input[i]) - '0';
                if (num < 0 || num > boardSize)
                    return false;
                numCounts[num]++;
                if (num != 0 && numCounts[num] > boardSize)
                    return false;
            }
            return true;
        }

        public void SetNumber(int row, int col, int number)
        {
            board[row, col].SetNum(number);
        }
        public Cell GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void SetCell(int row, int col, Cell cell)
        {
            board[row, col] = cell;
        }

        public int GetNumber(int row, int col)
        {
            return board[row, col].number;
        }
    }
}
