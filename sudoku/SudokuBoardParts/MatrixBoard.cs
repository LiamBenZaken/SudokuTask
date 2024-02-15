using sudoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace sudoku.SudokuBoardParts
{
    public class MatrixBoard : ISudokuBoard
    {
        public int boardSize { get; private set; }
        private Cell[,] board;
        public List<Cell> emptyCells{ get; private set; }

        public MatrixBoard(string input)
        {
            emptyCells = new List<Cell>();
            input = input.Replace(" ", "").Replace("/t", ""); // remove white spaces
            boardSize = (int)Math.Sqrt(input.Length);

            if (!IsValidBoard(boardSize, input))
                throw new NotValidBoardException(input.Length);

            board = new Cell[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j] = new Cell(i,j,(int)(input[i * boardSize + j]) - 48);
            InitCellsOptions();
        }

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
                    if (board[i, j].number != 0)
                        RemoveOptions(i, j);
                    InitConnectionCells(board[i, j],i,j);
                }
        }
        public HashSet<Cell> RemoveOptions(int row, int col)
        {
            HashSet<Cell> res = new HashSet<Cell>();
            Cell currentCell = board[row, col];

            int boxSize = (int)Math.Sqrt(boardSize);
            int boxStartRow = (row / boxSize) * boxSize;
            int boxStartCol = (col / boxSize) * boxSize;
            
            for (int c = 0; c < boardSize; c++)
                if (c != col && board[row,c].number == 0)
                    if (board[row, c].RemoveOption(currentCell.number))
                        res.Add(board[row, c]);

            for (int r = 0; r < boardSize; r++)
                if (r != row && board[r, col].number == 0)
                    if (board[r, col].RemoveOption(currentCell.number))
                        res.Add(board[r, col]);

            for (int r = boxStartRow; r < boxStartRow + boxSize; r++)
                for (int c = boxStartCol; c < boxStartCol + boxSize; c++)
                    if ((r != row || c != col) && board[r, c].number == 0)
                        if (board[r, c].RemoveOption(currentCell.number))
                            res.Add(board[r, c]);

            return res;
        }

        private void InitConnectionCells(Cell cell, int row, int col)
        {
            for (int j = 0; j < boardSize; j++)
                if (j != col && board[row, j].number == 0)
                    cell.connected.Add(board[row, j]);

            for (int i = 0; i < boardSize; i++)
                if (i != row && board[i, col].number == 0)
                    cell.connected.Add(board[i, col]);

            int boxSize = (int)Math.Sqrt(boardSize);
            int boxStartRow = (row / boxSize) * boxSize;
            int boxStartCol = (col / boxSize) * boxSize;
            for (int i = boxStartRow; i < boxStartRow + boxSize; i++)
                for (int j = boxStartCol; j < boxStartCol + boxSize; j++)
                    if ((i != row || j != col) && board[i, j].number == 0)
                        cell.connected.Add(board[i, j]);
        }
        public void SetNumber(int row, int col, int number)
        {
            board[row, col].SetNum(number);
        }

        public bool IsValidBoard(int boardSize, string input)
        {
            if (boardSize * boardSize != input.Length)
                return false;
            return true;
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
