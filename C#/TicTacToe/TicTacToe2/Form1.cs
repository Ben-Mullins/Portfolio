using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe2
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Business Logic goes in this class
        /// </summary>
        clsTicTacToe clsTicTac;
        /// <summary>
        /// Whether the game has been started or not
        /// </summary>
        bool isStarted;
        /// <summary>
        /// Default color of the buttons
        /// </summary>
        Color defaultColor;
        public Form1()
        {
            InitializeComponent();

            clsTicTac = new clsTicTacToe();
            isStarted = false;
            defaultColor = lbl00.BackColor;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            isStarted = true;
            resetColors();
            clearLabels();
        }

        private void spaceClick(object sender, EventArgs e)
        {
            Label myButton = (Label)sender;
            if (isStarted)
            {
                // is space blank
                if (myButton.Text == " ")
                {
                    int row = Convert.ToInt32(Char.GetNumericValue(myButton.Name[3])); // Holy cow, the work we put into converting a char to an int
                    int column = Convert.ToInt32(Char.GetNumericValue(myButton.Name[4]));
                    myButton.Text = clsTicTac.currPlayer;
                    clsTicTac.Board[row, column] = clsTicTac.currPlayer;
                    
                    if (clsTicTac.isWinningMove())
                    {
                        GameStatus.Text = clsTicTac.currPlayer + " won!";
                        // Highlight winning row/column/diag
                        if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Row1))
                        {
                            lbl00.BackColor = Color.Yellow;
                            lbl01.BackColor = Color.Yellow;
                            lbl02.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Row2))
                        {
                            lbl10.BackColor = Color.Yellow;
                            lbl11.BackColor = Color.Yellow;
                            lbl12.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Row3))
                        {
                            lbl20.BackColor = Color.Yellow;
                            lbl21.BackColor = Color.Yellow;
                            lbl22.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Col1))
                        {
                            lbl00.BackColor = Color.Yellow;
                            lbl10.BackColor = Color.Yellow;
                            lbl20.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Col2))
                        {
                            lbl01.BackColor = Color.Yellow;
                            lbl11.BackColor = Color.Yellow;
                            lbl21.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Col3))
                        {
                            lbl02.BackColor = Color.Yellow;
                            lbl12.BackColor = Color.Yellow;
                            lbl22.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Diag1))
                        {
                            lbl00.BackColor = Color.Yellow;
                            lbl11.BackColor = Color.Yellow;
                            lbl22.BackColor = Color.Yellow;
                        }
                        else if (clsTicTac.eWinningMove.Equals(clsTicTacToe.winningMove.Diag2))
                        {
                            lbl02.BackColor = Color.Yellow;
                            lbl11.BackColor = Color.Yellow;
                            lbl20.BackColor = Color.Yellow;
                        }
                        isStarted = false;
                        if (clsTicTac.currPlayer == "X")
                        {
                            clsTicTac.p1Wins++;
                            Player1Wins.Text = "Player 1 Wins: " + clsTicTac.p1Wins.ToString();
                        }
                        else
                        {
                            clsTicTac.p2Wins++;
                            Player2Wins.Text = "Player 2 Wins: " + clsTicTac.p2Wins.ToString();
                        }
                    }
                    else if (clsTicTac.isTie())
                    {
                        GameStatus.Text = "It was a tie!";
                        clsTicTac.Ties++;
                        GameTies.Text = "Ties: " + clsTicTac.Ties.ToString();
                        isStarted = false;
                    }
                    clsTicTac.changePlayer();
                    if (!clsTicTac.isWinningMove() && !clsTicTac.isTie())
                    {
                        GameStatus.Text = clsTicTac.currPlayer + "'s turn!";
                    }
                    
                }
            }
        }

        /// <summary>
        /// Resets the background color of all of the labels
        /// </summary>
        private void resetColors()
        {
            lbl00.BackColor = defaultColor;
            lbl01.BackColor = defaultColor;
            lbl02.BackColor = defaultColor;
            lbl10.BackColor = defaultColor;
            lbl11.BackColor = defaultColor;
            lbl12.BackColor = defaultColor;
            lbl20.BackColor = defaultColor;
            lbl21.BackColor = defaultColor;
            lbl22.BackColor = defaultColor;
        }

        /// <summary>
        /// Resets the text of our labels to empty
        /// </summary>
        private void clearLabels()
        {
            lbl00.Text = " ";
            lbl01.Text = " ";
            lbl02.Text = " ";
            lbl10.Text = " ";
            lbl11.Text = " ";
            lbl12.Text = " ";
            lbl20.Text = " ";
            lbl21.Text = " ";
            lbl22.Text = " ";
            GameStatus.Text = "New game! " + clsTicTac.currPlayer + "'s turn!";

            for (int i = 0; i < 3; ++i)
            {
                for (int k = 0; k < 3; ++k)
                {
                    clsTicTac.Board[i, k] = " ";
                }
            }
        }
    }
}
