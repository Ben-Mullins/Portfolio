using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2
{
    public class clsTicTacToe
    {
        /// <summary>
        /// Multidimensional array that holds the board values
        /// </summary>
        public string[,] Board;
        /// <summary>
        /// How many wins "X" has
        /// </summary>
        public int p1Wins;
        /// <summary>
        /// How many wins "O" has
        /// </summary>
        public int p2Wins;
        /// <summary>
        /// How many ties have occurred
        /// </summary>
        public int Ties;
        /// <summary>
        /// Who is the current player
        /// </summary>
        public string currPlayer;
        /// <summary>
        /// Which move was the winning move
        /// </summary>
        public winningMove eWinningMove;

        public clsTicTacToe()
        {
            p1Wins = 0;
            p2Wins = 0;
            Ties = 0;
            currPlayer = "X";
            Board = new string[3, 3];
        }

        public enum winningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        /// <summary>
        /// Changes which players turn it is
        /// </summary>
        public void changePlayer()
        {
            if (currPlayer == "X")
                currPlayer = "O";
            else
                currPlayer = "X";
        }

        /// <summary>
        /// Checks to see if there is a winning move on the board.
        /// </summary>
        /// <returns>True if the board has a winning move</returns>
        public bool isWinningMove()
        {
            bool hasWin = false;
            if (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2] && Board[0, 0] != " ")
            {
                eWinningMove = winningMove.Row1;
                hasWin = true;
            }
            else if (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2] && Board[1, 0] != " ")
            {
                eWinningMove = winningMove.Row2;
                hasWin = true;
            } 
            else if (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2] && Board[2, 0] != " ")
            {
                eWinningMove = winningMove.Row3;
                hasWin = true;
            }
            else if (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0] && Board[0, 0] != " ")
            {
                eWinningMove = winningMove.Col1;
                hasWin = true;
            }
            else if (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1] && Board[0, 1] != " ")
            {
                eWinningMove = winningMove.Col2;
                hasWin = true;
            }
            else if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2] && Board[0, 2] != " ")
            {
                eWinningMove = winningMove.Col3;
                hasWin = true;
            }
            else if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != " ")
            {
                eWinningMove = winningMove.Diag1;
                hasWin = true;
            }
            else if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != " ")
            {
                eWinningMove = winningMove.Diag2;
                hasWin = true;
            }
            return hasWin;
        }

        /// <summary>
        /// Checks to see if there is a tie (all spaces are filled up with no winner)
        /// </summary>
        /// <returns>True if there is a tie</returns>
        public bool isTie()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int k = 0; k < 3; ++k)
                {
                    if (Board[i, k] == " ")
                        return false;
                }
            }
            return true;
        }
    }
}
