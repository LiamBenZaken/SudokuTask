using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.SudokuBoardParts
{
    /// <summary>
    /// Represents a cell in a Sudoku board.
    /// </summary>
    public class Cell
    {
        public int number { get; private set; }
        public HashSet<int> options { get; private set; }
        public HashSet<Cell> connected { get; private set; }

        public int row { get; set; }
        public int col { get; set; }

        /// <summary>
        /// Initializes a new instance of the Cell class with the specified row, column, and number.
        /// </summary>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="col">The column index of the cell.</param>
        /// <param name="number">The number assigned to the cell.</param>
        public Cell(int row, int col, int number)
        {
            this.number = number;
            this.row = row;
            this.col = col;
            options = new HashSet<int>();
            connected = new HashSet<Cell>();
        }

        /// <summary>
        /// Adds a connection to another cell.
        /// </summary>
        /// <param name="cell">The cell to add as a connection.</param>
        public void AddConnection(Cell cell)
        {
            connected.Add(cell);
        }

        /// <summary>
        /// Removes a connection from another cell.
        /// </summary>
        /// <param name="cell">The cell to remove as a connection.</param>
        public void RemoveConnection(Cell cell)
        {
            connected.Remove(cell);
        }

        /// <summary>
        /// Adds an option to the cell's available options.
        /// </summary>
        /// <param name="option">The option to add.</param>
        public void AddOption(int option)
        {
            options.Add(option);
        }

        /// <summary>
        /// Removes an option from the cell's available options.
        /// </summary>
        /// <param name="option">The option to remove.</param>
        /// <returns><c>true</c> if the option was successfully removed; otherwise, <c>false</c>.</returns>
        public bool RemoveOption(int option)
        {
            return options.Remove(option);
        }

        /// <summary>
        /// Sets the number assigned to the cell.
        /// </summary>
        /// <param name="number">The number to set.</param>
        public void SetNum(int number)
        {
            this.number = number;
        }
    }
}
