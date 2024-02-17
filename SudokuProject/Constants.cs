using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SudokuProject
{
    public class Constants
    {
        public static char[] Values { get; set; }
        /// <summary>
        /// defines the size we work with
        /// </summary>
        /// <param name="size">the required size</param>
        public Constants(int size)
        {
            Values = Enumerable.Range('1', size).Select(i => (char)i).ToArray();
        }

    }
}
