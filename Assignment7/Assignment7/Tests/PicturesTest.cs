using Assignment7.Models;
using Assignment7.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7.Tests
{
    public static class PicturesTest
    {
        public const int NB_TESTS = 5;

        private static int noTest;
        private static List<Picture> pictures;
        private static bool hasBeenTested = false;
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

        public static void Init()
        {
            noTest = 0;
            hasBeenTested = true;

            List<Picture> lstPictures = new PicturesRepository().Pictures().ToList();

            pictures = new List<Picture>();

            while (pictures.Count < NB_TESTS && lstPictures.Count > 0)
            {
                Picture chosenPicture = lstPictures[new Random().Next(0, lstPictures.Count())];
                pictures.Add(chosenPicture);
                lstPictures.Remove(chosenPicture);
            }

            score = new Score
            {
                TestDate = DateTime.Now,
                Category = Category.Animal,
                AmountOfRightAnswers = 0,
                AmountOfQuestions = NB_TESTS
            };
        }

        public static Picture Next()
        {
            if (!hasBeenTested)
            {
                if (pictures == null || noTest >= pictures.Count)
                    return null;

                return pictures[noTest - 1];
            }

            if (noTest == pictures.Count())
                return null;

            Picture picture = pictures[noTest];
            noTest += 1;

            hasBeenTested = false;

            return picture;
        }

        public static bool Test(string animalName, string enteredName)
        {
            hasBeenTested = true;

            if (string.Compare(animalName, enteredName, true) == 0)
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