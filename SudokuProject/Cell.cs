using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class Cell
    {
        public char Clue { get; set; }
        public ISet<char> Candidates { get; set; }

        public Cell() 
        {
            this.Clue = '0';
            this.Candidates = new HashSet<char>(Constants.Values);
        }

        public Cell(char clue)
        {
            this.Clue = clue;
            this.Candidates = new HashSet<char>(Constants.Values);
            Candidates.Remove(clue);
        }
    }
}
