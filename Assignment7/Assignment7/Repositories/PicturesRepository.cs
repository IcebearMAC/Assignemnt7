using Assignment7.DataAccess;
using Assignment7.Models;
using System.Collections.Generic;

namespace Assignment7.Repositories
{
    public class PicturesRepository
    {
        EducationContext db = new EducationContext();

        public Picture Picture(int? id)
        {
            return db.Pictures.Find(id);
        }

        public IEnumerable<Picture> Pictures()
        {
            return db.Pictures;
        }

        public void Add(Picture Picture)
        {
            db.Pictures.Add(Picture);
            db.SaveChanges();
        }
    }
}