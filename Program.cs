using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {

        const double theFirstNumber = 0;
        const double theSecondNumber = 0;

        static void Main(string[] args)
        {
            
            double theFirstNumber = readDouble("please enter a number: ");                 //gets first number

            
            double theSecondNumber = readDouble("please enter another number: ");          //gets second number

            Console.WriteLine("Please enter a sign: + - * /");                             //reads your sign, performs the action
            string ReadTheSign = Console.ReadLine();
            switch (ReadTheSign)
            {
                case "+":
                    Console.WriteLine("the result is " + Added(theFirstNumber, theSecondNumber));
                    break;

                case "-":
                    Console.WriteLine("the result is " + Subtracted(theFirstNumber, theSecondNumber));
                    break;

                case "*":
                    Console.WriteLine("the result is " + Multiplied(theFirstNumber, theSecondNumber));
                    break;

                case "/":
                    Console.WriteLine("the result is " + Divided(theFirstNumber, theSecondNumber));
                    break;
                default:
                    Console.WriteLine("this is not a valid operation");
                    break;
            }

        }


        public static double readDouble(string label)
        {
            double thevalue1 = 0;
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine(label);
                string input = Console.ReadLine();
                if (double.TryParse(input, out thevalue1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("this isn't a real value.");
                    if (i == 2)
                        Environment.Exit(2);
                }

            }
            return thevalue1;
        }

        static double Added(double myval1, double myval2)
        {
            return myval1 + myval2;
        }
        static double Subtracted(double myval1, double myval2)
        {
            return myval1 - myval2;
        }
        static double Multiplied(double myval1, double myval2)
        {
            return myval1 * myval2;
        }
        static double Divided(double myval1, double myval2)
        {
            return myval1 / myval2;
        }








    }
}
