using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class FileInputHandler : IInputHandler
    {
        private readonly string _fileName;
        public FileInputHandler(string fileName) 
        { 
            _fileName = fileName;
        }

        public string GetInput()
        {
            return File.ReadAllText(_fileName);
        }
    }
}
