using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class ConsoleInputHandler : IInputHandler
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
