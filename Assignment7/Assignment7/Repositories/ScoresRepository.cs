using Assignment7.DataAccess;
using Assignment7.Models;
using System;
using System.Collections.Generic;
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

        public Score Score(Category category)
        {
            return Scores().FirstOrDefault(s => s.Category == category);
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