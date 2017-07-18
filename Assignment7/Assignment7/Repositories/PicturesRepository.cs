using Assignment7.DataAccess;
using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7.Repositories
{
    public class PicturesRepository : IDisposable
    {
        EducationContext db = new EducationContext();

        public IEnumerable<Picture> Pictures()
        {
            List<Picture> pictures = db.Pictures.ToList();

            foreach (Picture picture in pictures)
                picture.AnimalName = picture.AnimalName.Substring(0, 1).ToUpper() + picture.AnimalName.Substring(1).ToLower();

            return pictures;
        }

        public Picture Picture(string animalName)
        {
            return Pictures().FirstOrDefault(p => p.AnimalName == animalName);
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