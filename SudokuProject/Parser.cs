using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class Parser
    {
        private readonly IInputHandler _InputHandler;
        public string Input { get; private set; }
        public Parser(IInputHandler inputHandler) 
        {
            _InputHandler = inputHandler;
            Input = inputHandler.GetInput();
        }
        public void CheckLength()
        {
            if (Math.Sqrt(Input.Length) != Constants.Values.Count())
                throw new Exception("the input is not valid");
        }

        public void CheckChars()
        {
            for(int i = 0;i<Input.Length;i++)
            {
                if (!(Constants.Values.Contains(Input[i]) || Input[i] == '0'))
                    throw new Exception("the input is not valid");
            }
        }

        public void CheckValidation()
        {
            CheckLength();
            CheckChars();
        }

        public IBoard Parse(IBoard board)
        {
            CheckValidation();
            int IndexInInput = 0;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                    board.AddToBoard(i, j, Input[IndexInInput++]);
            }
            return board;
        }
    }
}
