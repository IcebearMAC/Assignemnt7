using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment7.Exercises
{
    public class CalculusExcercises
    {

        private static int FirstNumber = 0;
        private static int SecondNumber = 0;
        private static int Operators = 0;
        private static double Answer = 0;
        public static double PupilAnswer { get; set; }
        private static Score score = null;

        public static int NoTest
        {
            get { return noTest; }
            set { }
        }

        public static Score Score
        {
            get { return score; }
            set { }
        }



        private void Randomizier()
        {
            Random Number = new Random();
            FirstNumber = Number.Next(0, 9);
            SecondNumber = Number.Next(0, 9);
            Operators = Number.Next(1, 5);

        }

        private void Calculation()
        {
            switch (Operators)
            {
                case 1:
                    Answer = FirstNumber + SecondNumber;
                    break;
                case 2:
                    Answer = FirstNumber - SecondNumber;
                    break;
                case 3:
                    Answer = FirstNumber * SecondNumber;
                    break;
                case 4:
                    Answer = FirstNumber / SecondNumber;
                    break;
                default:
                    break;
            }
        }

        private void AnswerCheck()
        {
            if (Answer == PupilAnswer)
            {

            }
            else
            {

            }
        }
    }
}