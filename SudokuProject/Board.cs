using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class Board : IBoard
    {
        public int Size { get; set; }
        public Cell[,] Matrix { get; set; }
        private readonly IBoardPrinter printer;

        public Board()
        {
            
        }
        public Board(int size, IBoardPrinter printer)
        {
            this.Size = size;
            this.Matrix = new Cell[size, size];
            this.printer = printer;
        }

        public void AddToBoard(int row, int col, char val)
        {
            if(row < 0 || col < 0 || row > this.Size || col > this.Size)
                throw new ArgumentOutOfRangeException("row or column not valid");
            if(val == '0')
                this.Matrix[row, col] = new Cell();
            else
                this.Matrix[row, col] = new Cell(val);
        }

        public void PrintBoard()
        {
            printer.Print(this);
        }
    }
}
