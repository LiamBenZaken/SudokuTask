using sudoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.InputAndOutput
{
    public class SudokuBoardFormatter
    {
        private static void PrintHorizontalLine(int blockWidth, string horizontalBlockSeparator, char symbol)
        {
            for (int i = 0; i < blockWidth; i++)
                Console.Write(symbol + horizontalBlockSeparator);
            Console.Write(symbol);
            Console.WriteLine();
        }

        private static void PrintWithColor(int[,] board , int i , int j)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write((char)(board[i, j] + '0'));
            Console.ForegroundColor = originalColor;
        }
        public static void PrintBoard(int[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            int blockHeight = (int)Math.Sqrt(rows);
            int blockWidth = (int)Math.Sqrt(cols);

            int tempBlockWidth = blockWidth;

            if (Math.Sqrt(cols) != blockWidth)
                tempBlockWidth++;

            int horizontalBlockSeparatorLength = blockWidth * 2 + 1;
            string horizontalBlockSeparator = new string('-', horizontalBlockSeparatorLength);

            PrintHorizontalLine(tempBlockWidth, horizontalBlockSeparator,'+');

            for (int i = 0; i < rows; i++)
            {
                if (i != 0 && i % blockHeight == 0)
                    PrintHorizontalLine(tempBlockWidth, horizontalBlockSeparator, '-');
                Console.Write("| ");
                for (int j = 0; j < cols; j++)
                {
                    if (j != 0 && j % blockWidth == 0)
                        Console.Write("| ");
                    PrintWithColor(board, i, j);                   
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            PrintHorizontalLine(tempBlockWidth, horizontalBlockSeparator, '+');
        }

        public static int[,] FormatInputToBoard(string input) 
        {
            input = input.Replace(" ", "").Replace("/t",""); // remove white spaces
            int size = (int)Math.Sqrt(input.Length);

            Console.WriteLine(input.Length);

            if (size * size != input.Length)
            {
                throw new NotValidBoardException(input.Length);
            }

            int[,] board = new int[size,size];
             
            for (int i = 0;i < size;i++)         
                for(int j = 0;j < size;j++)
                    board[i, j] = (int)(input[i * size + j]) - 48;

            return board;
        }
    }
}
