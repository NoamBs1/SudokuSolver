using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal interface IBoard
    {
        int Size { get; set; }
        void AddToBoard(int row, int col, char val);
    }
}
