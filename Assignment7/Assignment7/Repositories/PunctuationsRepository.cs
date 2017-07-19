using Assignment7.DataAccess;
using Assignment7.Exercises.Punctuations;
using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7.Repositories
{
    public class PunctuationsRepository : IDisposable
    {
        EducationContext db = new EducationContext();

        public IEnumerable<int> PunctuationIDs()
        {
            return db.Punctuations.Select(p => p.ID);
        }

        public Punctuation Punctuation(int id)
        {
            return db.Punctuations.FirstOrDefault(p => p.ID == id);
        }

        public List<Character> Split(string text)
        {
            int i = 0;
            List<Character> result = new List<Character>();

            foreach (char c in text)
            {
                Character @char = new Character { Value = c.ToString() };

                if (PunctuationExercises.PunctuationMarks.Contains(c))
                {
                    @char.IsPunctuationMark = true;
                    @char.EnteredValue = "*";
                }

                result.Add(@char);

                i += 1;
            }

            return result;
        }

        public string Join(List<Character> characters, List<Character> enteredPunctuationMarks)
        {
            string result = string.Empty;

            int i = 0;
            foreach (Character @char in characters)
            {
                if (@char.IsPunctuationMark)
                {
                    result += enteredPunctuationMarks[i].EnteredValue.ToString();
                    i += 1;
                }
                else
                    result += @char.Value.ToString();
            }

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                db.Dispose();
                disposedValue = true;
            }
        }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}