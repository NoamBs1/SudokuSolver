using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public interface IBoard
    {
        int Size { get; set; }
        Cell[,] Matrix { get; set; }
        bool AddToBoard(int row, int col, char val);
        void PrintBoard();
        object Clone();
    }
}
