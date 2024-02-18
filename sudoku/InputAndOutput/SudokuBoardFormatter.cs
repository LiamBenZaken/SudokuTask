using sudoku.Exceptions;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    // <summary>
    /// Provides methods to format and print Sudoku boards.
    /// </summary>
    public class SudokuBoardFormatter
    {
        /// <summary>
        /// Converts the Sudoku board to a string representation.
        /// </summary>
        /// <param name="board">The Sudoku board to convert.</param>
        /// <returns>A string representation of the Sudoku board.</returns>
        public static string BoardAsString(ISudokuBoard board)
        {
            string solvedBoard = "";
            for (int i = 0; i < board.boardSize; i++)
                for (int j = 0; j < board.boardSize; j++)
                    solvedBoard += (char)(board.GetCell(i, j).number + '0');
            return solvedBoard;
        }

        /// <summary>
        /// Prints a horizontal line with block separators and a specified symbol.
        /// </summary>
        /// <param name="blockHeightAndWidth">The height and width of each block.</param>
        /// <param name="horizontalBlockSeparator">The separator between blocks.</param>
        /// <param name="symbol">The symbol used for the horizontal line.</param>
        private static void PrintHorizontalLine(int blockHeightAndWidth, string horizontalBlockSeparator, char symbol)
        {
            for (int i = 0; i < blockHeightAndWidth; i++)
                Console.Write(symbol + horizontalBlockSeparator);
            Console.Write(symbol);
            Console.WriteLine();
        }


        /// <summary>
        /// Prints a cell of the Sudoku board with color.
        /// </summary>
        /// <param name="board">The Sudoku board.</param>
        /// <param name="i">The row index of the cell.</param>
        /// <param name="j">The column index of the cell.</param>
        private static void PrintWithColor(ISudokuBoard board, int i, int j)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write((char)(board.GetCell(i, j).number + '0'));
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Prints the Sudoku board with horizontal lines and block separators.
        /// </summary>
        /// <param name="board">The Sudoku board to print.</param>
        public static void PrintBoard(ISudokuBoard board)
        {
            int blockHeightAndWidth = (int)Math.Sqrt(board.boardSize);
            int temp = blockHeightAndWidth;

            if (Math.Sqrt(board.boardSize) != blockHeightAndWidth)
                temp++;

            int horizontalBlockSeparatorLength = blockHeightAndWidth * 2 + 1;
            string horizontalBlockSeparator = new string('-', horizontalBlockSeparatorLength);

            PrintHorizontalLine(temp, horizontalBlockSeparator, '+');

            for (int i = 0; i < board.boardSize; i++)
            {
                if (i != 0 && i % blockHeightAndWidth == 0)
                    PrintHorizontalLine(temp, horizontalBlockSeparator, '-');
                Console.Write("| ");
                for (int j = 0; j < board.boardSize; j++)
                {
                    if (j != 0 && j % blockHeightAndWidth == 0)
                        Console.Write("| ");
                    PrintWithColor(board, i, j);
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            PrintHorizontalLine(temp, horizontalBlockSeparator, '+');
        }
    }
}
