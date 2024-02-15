using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal partial class Solver
    {
        public bool NakedSingle(IBoard b)
        {
            bool flag = false;
            for (int i = 0; i < b.Size; i++)
            {
                for (int j = 0; j < b.Size; j++)
                {
                    if (b.Matrix[i, j].Clue == '0' && b.Matrix[i, j].Candidates.Count == 1)
                    {
                        if (b.AddToBoard(i, j, b.Matrix[i, j].Candidates.Last()))
                            flag = true;
                    }
                }
            }
            return flag;
        }
    }
}
