using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.SudokuBoardParts
{
    public class Cell
    {
        public int number { get; private set; }
        public HashSet<int> options { get; private set; }
        public HashSet<Cell> connected {  get; private set; }

        public int row { get;  set; }
        public int col { get; set; }

        public Cell(int row,int col,int number)
        {
            this.number = number;
            this.row = row;
            this.col = col;
            options = new HashSet<int>();
            connected = new HashSet<Cell>();
        }
        public void AddConnection(Cell cell)
        {
            connected.Add(cell);
        }
        public void RemoveConnection(Cell cell) 
        {
            connected.Remove(cell);
        }
        public void AddOption(int option)
        {
            options.Add(option);
        }

        public bool RemoveOption(int option)
        {
            return options.Remove(option);
        }

        public void SetNum(int number)
        {
            this.number = number;
        }
    }
}
