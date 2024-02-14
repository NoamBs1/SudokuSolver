using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// writes the board to a file
    /// </summary>
    internal class BoardPrinterFile : IBoardPrinter
    {
        public string FilePath;
        /// <summary>
        /// Initialized the path of the required file
        /// </summary>
        /// <param name="filePath">path of the file</param>
        public BoardPrinterFile(string filePath) 
        { 
            FilePath = filePath;
        }
        /// <summary>
        /// prints the board to the file
        /// </summary>
        /// <param name="board">the board you want to write</param>
        public void Print(IBoard board)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.WriteLine(Parser.ConvertToString(board));
            }
        }
    }
}
