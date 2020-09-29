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
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Shapes;

namespace dragonMath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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

        private void start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int age = -1;
                Int32.TryParse(boxAge.Text, out age);

                string selectedMode;

                if (rdioAdd.IsChecked == true)
                    selectedMode = "add";
                else if (rdioSub.IsChecked == true)
                    selectedMode = "sub";
                else if (rdioMult.IsChecked == true)
                    selectedMode = "mul";
                else
                    selectedMode = "div";

                if (boxName.Text != "")
                {
                    if (age != -1 && age >= 3 && age <= 10)
                    {
                        scoreMgr.age = age;
                        scoreMgr.name = boxName.Text;
                        // Start game
                        this.Hide();
                        Window1 gameWindow = new Window1(selectedMode);
                        gameWindow.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        lblError.Content = "Enter Valid Age (3-10)";
                    }
                }
                else
                {
                    lblError.Content = "Please enter a name";
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
