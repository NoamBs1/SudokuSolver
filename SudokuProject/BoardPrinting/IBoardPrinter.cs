using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// interface of printing a board
    /// </summary>
    internal interface IBoardPrinter
    {
        void Print(IBoard board);
    }
}
