using Assignment7.DataAccess;
using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Assignment7.Repositories
{
    public class ScoresRepository : IDisposable
    {
        EducationContext db = new EducationContext();

        public IEnumerable<Score> Scores()
        {
            return db.Scores;
        }

        public void Add(Score score)
        {
            db.Scores.Add(score);
            db.SaveChanges();
        }

        public Score Score(Category category)
        {
            return Scores().FirstOrDefault(s => s.Category == category);
        }

        public Score Score(int? id)
        {
            return Scores().FirstOrDefault(s => s.ID == id);
        }

        public void Delete(int? id)
        {
            db.Scores.Remove(Score(id));
            db.SaveChanges();
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