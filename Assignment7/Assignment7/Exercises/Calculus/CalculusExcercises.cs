using Assignment7.Models;
using Assignment7.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment7.Exercises.Calculus
{
    public class CalculusExercises
    {
        #region Variable
        private static int noTest = 0;
        private static int firstNumber = 0;
        private static int secondNumber = 0;
        private static int operators = 0;
        private static double answer = 0;
        private static Score score = null;
        private static string viewOperator;

        public static int FirstNumber
        {
            get { return firstNumber; }
            private set { }
        }

        public static int SecondNumber
        {
            get { return secondNumber; }
            private set { }
        }

        public static string ViewOperator
        {
            get { return viewOperator; }
            private set { }
        }

        public static double Answer
        {
            get { return answer; }
            private set { }
        }

        public static Score Score
        {
            get { return score; }
            private set { }
        }
        #endregion

        private static void Randomizer()
        {
            Random Number = new Random();
            firstNumber = Number.Next(0, 9);
            secondNumber = Number.Next(0, 9);
            operators = Number.Next(1, 5);
            ShowOperator(operators);
        }

        private static void Calculation()
        {
            switch (operators)
            {
                case 1:
                    answer = firstNumber + secondNumber;
                    break;
                case 2:
                    answer = firstNumber - secondNumber;
                    break;
                case 3:
                    answer = firstNumber * secondNumber;
                    break;
                case 4:
                    while (secondNumber == 0)
                    {
                        secondNumber = new Random().Next(1, 9);
                    }
                    answer = firstNumber / secondNumber;
                    break;
                default:
                    break;
            }
        }

        public static void Init()
        {
            Randomizer();
            Calculation();

            score = new Score
            {
                TestDate = DateTime.Now,
                Category = Category.Calculus,
                AmountOfRightAnswers = 0,
                AmountOfQuestions = 1
            };
        }

        private static void ShowOperator(int operators)
        {
            switch (operators)
            {
                case 1:
                    viewOperator = "+";
                    break;
                case 2:
                    viewOperator = "-";
                    break;
                case 3:
                    viewOperator = "*";
                    break;
                case 4:
                    viewOperator = "/";
                    break;
                default:
                    break;
            }
        }

        public static bool Test(double pupilAnswer)
        {
            if (score == null)
                return false;

            if (answer == pupilAnswer)
                score.AmountOfRightAnswers += 1;

            return score.AmountOfRightAnswers == score.AmountOfQuestions;
        }

        public static void End()
        {
            if (score != null)
                new ScoresRepository().Add(score);

            score = null;
        }
    }
}