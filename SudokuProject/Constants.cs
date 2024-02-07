using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SudokuProject
{
    internal class Constants
    {
        public static readonly char[] Values = Enumerable.Range('1', 9).Select(i => (char) i).ToArray();

    }
}
