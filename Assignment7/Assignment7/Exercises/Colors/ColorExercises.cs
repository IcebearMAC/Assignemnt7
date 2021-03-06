﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment7.Models;
using Assignment7.Repositories;

namespace Assignment7.Exercises.Colors
{
    public static class ColorExercises
    {
        private static ColorRepository db = new ColorRepository();

        public const int NB_TESTS = 5;

        private static int noTest;
        private static List<List<Color>> colors;
        private static bool hasBeenTested = false;
        private static Score score = null;

        public static int NoTest
        {
            get { return noTest; }
            private set { }
        }

        public static Score Score
        {
            get { return score; }
            private set { }
        }

        public static void Init()
        {
            noTest = 0;
            hasBeenTested = true;

            List<Color> lstPrev = new List<Color>();
            colors = new List<List<Color>>();

            for (int i = 0; i < NB_TESTS; i += 1)
            { 
                List<Color> lstNext;
                do
                {
                    lstNext = db.Randomize().ToList();
                } while (lstNext.SequenceEqual(lstPrev));

                colors.Add(lstNext);
                lstPrev = lstNext;
            }

                score = new Score
                {
                    TestDate = DateTime.Now,
                    Category = Category.Color,
                    AmountOfRightAnswers = 0,
                    AmountOfQuestions = NB_TESTS
                };
        }

        public static List<Color> Next()
        {
            if (!hasBeenTested)
            {
                if (colors == null || noTest >= colors.Count)
                    return null;

                return colors[noTest - 1];
            }

            if (noTest == colors.Count())
                return null;

            List<Color> color = colors[noTest];
            noTest += 1;

            hasBeenTested = false;

            return color;
        }

        public static bool Test(string colorName, string enteredName)
        {
            hasBeenTested = true;

            if (string.Compare(colorName, enteredName, true) == 0)
            {
                score.AmountOfRightAnswers += 1;
                return true;
            }

            return false;
        }

        public static void End()
        {
            if (score != null)
                new ScoresRepository().Add(score);

            score = null;
        }
    }
}