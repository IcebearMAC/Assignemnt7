using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment7.DataAccess;
using Assignment7.Models;

namespace Assignment7.Repositories
{
    public class WordRepository
    {

        EducationContext db = new EducationContext();

        public Word Word(int id)
        {
            return db.Words.FirstOrDefault(w => w.Id == id);
        }

        public Word RandomWords()
        {
            List<Word> words = db.Words.ToList();

            return words[new Random().Next(0, words.Count)];
        }

        public List<string> Randomize(Word word)
        {
            List<string> split = word.Words.Split(new string[] { " " },
                                                                                StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> result = new List<string>();

            while (split.Count > 0)
            {
                int index = new Random().Next(0, split.Count);
                result.Add(split[index]);
                split.RemoveAt(index);
            }

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                db.Dispose();
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}