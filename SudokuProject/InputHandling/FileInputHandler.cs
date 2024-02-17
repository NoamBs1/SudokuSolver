using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class FileInputHandler : IInputHandler
    {
        private readonly string _fileName;
        public FileInputHandler(string fileName)
        {
            _fileName = fileName;
        }

        public string GetInput()
        {
            try
            {
                return File.ReadAllText(_fileName);
            }
            catch
            {
                throw new Exception("can not locate or read from this file");
            }
        }
    }
}
