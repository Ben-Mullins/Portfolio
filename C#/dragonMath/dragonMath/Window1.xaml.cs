using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using System.Windows.Threading;

namespace dragonMath
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// myTimer is a timer for our game
        /// </summary>
        DispatcherTimer myTimer;
        /// <summary>
        /// What time you start the game at
        /// </summary>
        DateTime startTime = DateTime.Now;
        /// <summary>
        /// Type of game, supplied when window is instantiated
        /// </summary>
        string gameType;
        /// <summary>
        /// If game has started or not
        /// </summary>
        bool isStarted = false;
        /// <summary>
        /// equation data is stored in eqData
        /// </summary>
        string[] eqData = new string[2];
        /// <summary>
        /// Creating our equation generator pointer
        /// </summary>
        equationGenerator eqGen;
        /// <summary>
        /// How many questions are answered
        /// </summary>
        int questionsAnswered;

        public Window1(string Mode)
        {
            gameType = Mode;
            InitializeComponent();
        }

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Controls the timer tick
        /// </summary>
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeDiff = new TimeSpan(); // Difference in time
                timeDiff = DateTime.Now.Subtract(startTime);
                string timeElapsed = ((int)timeDiff.TotalSeconds).ToString();
                lblTimer.Content = timeElapsed;
                scoreMgr.currTime = timeElapsed;
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Determines whether the game has started or not, then either starts the
        /// game or submits the answer entered in the box.
        /// </summary>
        private void submitStart()
        {
            try
            {
                // Either Start Game Or Submit Answer
                if (isStarted)
                {
                    if (questionsAnswered < 10)
                    {
                        questionsAnswered++;

                        //Check Answer
                        if (boxAnswer.Text == eqData[1])
                        {
                            scoreMgr.currCorrect++;
                            lblstatus.Content = "Correct!";
                        }
                        else
                            lblstatus.Content = "Incorrect!";


                        eqData = eqGen.generateEq();
                        lblQuestion.Content = eqData[0];
                        boxAnswer.Text = "";
                    }
                    else
                    {
                        //end game, go to high scores
                        Window2 scoreWindow = new Window2();
                        if (scoreMgr.currCorrect <= 4)
                        {
                            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(@"Images\slow.jpg", UriKind.Relative)));
                            scoreWindow.MainBack.Background = myBrush;
                        }
                        else if (scoreMgr.currCorrect > 4 && scoreMgr.currCorrect <= 7)
                        {
                            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(@"Images\Medium.jpg", UriKind.Relative)));
                            scoreWindow.MainBack.Background = myBrush;
                        }
                        else if (scoreMgr.currCorrect > 7)
                        {
                            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(@"Images\fast.jpg", UriKind.Relative)));
                            scoreWindow.MainBack.Background = myBrush;
                        }
                        this.Hide();
                        scoreWindow.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    scoreMgr.currCorrect = 0;
                    questionsAnswered = 0;
                    startTimer();
                    lblstatus.Content = "";
                    btnSubmit.Content = "Submit";
                    isStarted = true;
                    eqGen = new equationGenerator(gameType);
                    eqData = eqGen.generateEq();
                    lblQuestion.Content = eqData[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                submitStart();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Starts the timer for a game
        /// </summary>
        private void startTimer()
        {
            try
            {
                myTimer = new DispatcherTimer();
                myTimer.Interval = TimeSpan.FromSeconds(1);
                myTimer.Start();
                myTimer.Tick += MyTimer_Tick;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void enterSubmit(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    submitStart();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
