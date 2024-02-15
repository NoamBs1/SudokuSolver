using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// this class manage the input getting, and transform it into a board
    /// </summary>
    internal class Parser
    {
        private readonly IInputHandler _InputHandler;
        public string Input { get; private set; }
        /// <summary>
        /// Initialized the parser with the way you want to get your input
        /// </summary>
        /// <param name="inputHandler">the way you want to get the input</param>
        public Parser(IInputHandler inputHandler)
        {
            _InputHandler = inputHandler;
            Input = inputHandler.GetInput();
        }
        /// <summary>
        /// checks if the length of the input is valid for a board
        /// </summary>
        /// <exception cref="Exception">if not valid length</exception>
        public void CheckLength()
        {
            if (Math.Sqrt(Input.Length) != Constants.Values.Count())
                throw new Exception("the input is not valid - length doesn't match");
        }
        /// <summary>
        /// checks if a string contains only valid chars due to the length of the input
        /// </summary>
        /// <exception cref="Exception">if there is a not valid char</exception>
        public void CheckChars()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (!(Constants.Values.Contains(Input[i]) || Input[i] == '0'))
                    throw new Exception("the input is not valid - chars don't match");
            }
        }
        /// <summary>
        /// checks if the length and the chars are valid
        /// </summary>
        public void CheckValidation()
        {
            CheckLength();
            CheckChars();
        }
        /// <summary>
        /// converting the input to a board
        /// </summary>
        /// <param name="board">an empty, initialized board</param>
        /// <returns>the board with the chars due to the input string</returns>
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
        /// <summary>
        /// converts the board to a string
        /// </summary>
        /// <param name="board">the board you want to convert</param>
        /// <returns>the stringed board</returns>
        public static string ConvertToString(IBoard board)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i < board.Size; i++)
                for(int j=0; j < board.Size;j++)
                    sb.Append(board.Matrix[i,j].Clue);
            return sb.ToString();
        }
    }
}
