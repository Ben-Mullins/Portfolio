using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragonMath
{
    /// <summary>
    /// Generates a random equation for the user to solve
    /// </summary>
    public class equationGenerator
    {
        /// <summary>
        /// Gamemode selected
        /// </summary>
        private string mode;
        /// <summary>
        /// Random number generator
        /// </summary>
        Random rand = new Random();
        /// <summary>
        /// Instantiates a random equation generator
        /// </summary>
        /// <param name="gameMode">add, sub, mul, or div</param>
        public equationGenerator(string gameMode)
        {
            mode = gameMode;
        }

        /// <summary>
        /// Generates an equation of the given type defined when the object is created.
        /// </summary>
        /// <returns>string[2]. string[0] == equation, string[1] == answer</returns>
        public string[] generateEq()
        {
            string[] data = new string[2];
            if (mode == "add")
            {
                int num1 = rand.Next(1, 11);
                int num2 = rand.Next(1, 11);
                data[0] = num1.ToString() + " + " + num2.ToString() + " =";
                data[1] = (num1 + num2).ToString();
            }
            else if (mode == "sub")
            {
                int num1 = 0;
                int num2 = 10;
                while (num1 < num2)
                {
                    num1 = rand.Next(1, 11);
                    num2 = rand.Next(1, 11);
                }
                data[0] = num1.ToString() + " - " + num2.ToString() + " =";
                data[1] = (num1 - num2).ToString();
            }
            else if (mode == "mul")
            {
                int num1 = rand.Next(1, 11);
                int num2 = rand.Next(1, 11);
                data[0] = num1.ToString() + " x " + num2.ToString() + " =";
                data[1] = (num1 * num2).ToString();
            }
            else if (mode == "div")
            {
                int answer = rand.Next(1, 6);
                data[1] = answer.ToString();
                if (answer == 1)
                {
                    int num1 = rand.Next(1, 11);
                    int num2 = num1;
                    data[0] = num1.ToString() + "/" + num2.ToString() + " =";
                }
                else if (answer == 2)
                {
                    int num2 = rand.Next(1, 6);
                    int num1 = num2 * 2;
                    data[0] = num1.ToString() + "/" + num2.ToString() + " =";
                }
                else if (answer == 3)
                {
                    int num2 = rand.Next(1, 4);
                    int num1 = num2 * 3;
                    data[0] = num1.ToString() + "/" + num2.ToString() + " =";
                }
                else if (answer == 4)
                {
                    int num2 = rand.Next(1, 3);
                    int num1 = num2 * 4;
                    data[0] = num1.ToString() + "/" + num2.ToString() + " =";
                }
                else if (answer == 5)
                {
                    int num2 = rand.Next(1, 2);
                    int num1 = num2 * 5;
                    data[0] = num1.ToString() + "/" + num2.ToString() + " =";
                }
            }
            return data;
        }
    }
}
