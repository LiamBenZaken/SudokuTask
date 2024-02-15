using sudoku.Exceptions;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    public class SudokuBoardFormatter
    {
        public static string BoardAsString(ISudokuBoard board)
        {
            string solvedBoard="";
            for (int i = 0; i < board.boardSize; i++)
                for (int j = 0; j < board.boardSize; j++)
                    solvedBoard += (char)(board.GetCell(i, j).number + '0');
            return solvedBoard;
        }
        private static void PrintHorizontalLine(int blockHeightAndWidth, string horizontalBlockSeparator, char symbol)
        {
            for (int i = 0; i < blockHeightAndWidth; i++)
                Console.Write(symbol + horizontalBlockSeparator);
            Console.Write(symbol);
            Console.WriteLine();
        }

        private static void PrintWithColor(ISudokuBoard board , int i , int j)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write((char)(board.GetCell(i,j).number + '0'));
            Console.ForegroundColor = originalColor;
        }
        public static void PrintBoard(ISudokuBoard board)
        {
            int blockHeightAndWidth = (int)Math.Sqrt(board.boardSize);
            int temp = blockHeightAndWidth;

            if (Math.Sqrt(board.boardSize) != blockHeightAndWidth)
                temp++;

            int horizontalBlockSeparatorLength = blockHeightAndWidth * 2 + 1;
            string horizontalBlockSeparator = new string('-', horizontalBlockSeparatorLength);

            PrintHorizontalLine(temp, horizontalBlockSeparator,'+');

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
