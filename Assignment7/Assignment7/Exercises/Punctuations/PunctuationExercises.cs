using Assignment7.Models;
using Assignment7.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7.Exercises.Punctuations
{
    public static class PunctuationExercises
    {
        public static List<char> PunctuationMarks = new List<char> { ',', '.', ';', ':', '!', '?' };

        private static Punctuation punctuation;
        private static Score score = null;

        public static Punctuation Punctuation
        {
            get { return punctuation; }
            private set { }
        }

        public static Score Score
        {
            get { return score; }
            private set { }
        }

        public static void Init()
        {
            PunctuationsRepository pr = new PunctuationsRepository();
            List<int> punctuationIds = pr.PunctuationIDs().ToList();

            punctuation = pr.Punctuation(punctuationIds[new Random().Next(0, punctuationIds.Count())]);

            score = new Score
            {
                TestDate = DateTime.Now,
                Category = Category.Text,
                AmountOfRightAnswers = 0,
                AmountOfQuestions = NbPunctuationMarks(punctuation.Text)
            };
        }

        public static bool Test(List<Character> result)
        {
            if (score == null)
                return false;

            foreach (Character c in result)
            {
                if (c.IsPunctuationMark && c.Value == c.EnteredValue)
                    score.AmountOfRightAnswers += 1;
            }

            return score.AmountOfRightAnswers == score.AmountOfQuestions;
        }

        public static void End()
        {
            if (score != null)
                new ScoresRepository().Add(score);

            score = null;
        }

        private static int NbPunctuationMarks(string text)
        {
            return text.Where(c => PunctuationMarks.Contains(c)).Count();
        }
    }
}