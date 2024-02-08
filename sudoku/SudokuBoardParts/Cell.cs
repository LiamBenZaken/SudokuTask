using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.SudokuBoardParts
{
    public class Cell
    {
        public int number{ get; private set;}
        public HashSet<int> options { get; private set; }

        public Cell(int number) 
        { 
            this.number = number;
            options = new HashSet<int>();
        }

        public void AddOption(int option) 
        {
            options.Add(option);
        }

        public void RemoveOption(int option) 
        { 
            options.Remove(option);
        }

        public void SetNum(int number)
        {
            this.number = number;
            options.Clear();
        }

    }
}
