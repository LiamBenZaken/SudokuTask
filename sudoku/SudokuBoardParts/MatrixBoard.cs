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
        public List<Cell> emptyCells { get; private set; }

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

        private void InitConnectionCells(Cell cell, int row, int col)
        {
            for (int j = 0; j < boardSize; j++)
                if (j != col)
                    cell.connected.Add(board[row, j]);

            for (int i = 0; i < boardSize; i++)
                if (i != row)
                    cell.connected.Add(board[i, col]);

            int boxSize = (int)Math.Sqrt(boardSize);
            int boxStartRow = (row / boxSize) * boxSize;
            int boxStartCol = (col / boxSize) * boxSize;
            for (int i = boxStartRow; i < boxStartRow + boxSize; i++)
                for (int j = boxStartCol; j < boxStartCol + boxSize; j++)
                    if (i != row || j != col)
                        cell.connected.Add(board[i, j]);
        }
        public void SetNumber(int row, int col, int number)
        {
            board[row, col].SetNum(number);
        }

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
                if (num!= 0 &&numCounts[num] > boardSize)
                    return false;
            }

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
