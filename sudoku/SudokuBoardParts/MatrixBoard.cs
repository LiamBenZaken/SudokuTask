using sudoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.SudokuBoardParts
{
    internal class MatrixBoard : ISudokuBoard
    {
        public int boardSize { get; private set; }
        public Cell[,] board;

        public MatrixBoard(string input)
        {
            input = input.Replace(" ", "").Replace("/t", ""); // remove white spaces
            boardSize = (int)Math.Sqrt(input.Length);

            if(!IsValidBoard(boardSize,input))
                throw new NotValidBoardException(input.Length);

            board = new Cell[boardSize,boardSize];

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    board[i, j] = new Cell((int)(input[i * boardSize + j]) - 48);

        }

        public void InitCellsOptions()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i,j].number == 0)
                    {
                        for (int k = 1; k <= boardSize; k++)
                            board[i, j].AddOption(k);
                        RemoveOptionsByRow(i, j);
                        RemoveOptionsByColumn(i, j);
                        RemoveOptionsByBox(i, j);
                    }    
                }
            }
        }

        private void RemoveOptionsByBox(int row, int col)
        {
            int boxSize = (int)Math.Sqrt(boardSize);
            int boxRow = row / boxSize * boxSize;
            int boxCol = col / boxSize * boxSize;

            for (int i = boxRow; i < boxRow+boxSize; i++)
                for (int j = boxCol; j < boxCol+boxSize; j++)
                    if((i != row || j != col) && board[i, j].number != 0)
                        board[row, col].RemoveOption(board[i, j].number);

        }

        private void RemoveOptionsByColumn(int row, int col)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (i != row && board[i, col].number != 0)
                    board[row, col].RemoveOption(board[i, col].number);
            }
        }

        private void RemoveOptionsByRow(int row, int col)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (i != col && board[row, i].number != 0)
                    board[row, col].RemoveOption(board[row, i].number);
            }
        }

        public void SetNumber(int row, int col, int number)
        {
            board[row,col].SetNum(number);
            RemoveOptionsByRow(row, col);
            RemoveOptionsByColumn(row, col);
            RemoveOptionsByBox(row, col);
        }

        public bool IsValidBoard(int boardSize,string input)
        {
            if (boardSize * boardSize != input.Length)
                return false;
            return true;
        }

        public Cell GetCell(int row, int col)
        {
            return board[row, col];
        }
    }
}
