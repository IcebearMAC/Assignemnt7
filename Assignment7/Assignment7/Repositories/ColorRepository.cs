using Assignment7.DataAccess;
using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment7.Repositories
{
    public class ColorRepository
    {
        EducationContext db = new EducationContext();

        public Color Color(int? id)
        {
            return db.Colors.Find(id);
        }

        public IEnumerable<Color> Colors()
        {
            return db.Colors;
        }

        public Color GetByName(string name)
        {
            return db.Colors.Where(c => c.Name == name).FirstOrDefault();
        }

        public IEnumerable<Color> GetByType(System.Drawing.Color color)
        {
            return db.Colors.Where(c => c.Colors == color);
        }

        public IEnumerable<Color> Randomize()
        {
            List<int> ColorIDs = db.Colors.Select(c => c.ID).ToList();

            List<int> RandomListID =new List<int>();

            for (int i = 0; i < 4; i += 1)
            {
                int randomId = ColorIDs[ new Random().Next(0, ColorIDs.Count)];
                RandomListID.Add(randomId);
                ColorIDs.Remove(randomId);
            }

            return db.Colors.Where(c => RandomListID.Contains(c.ID));
        }

        public void Add(Color color)
        {
            db.Colors.Add(color);
            db.SaveChanges();
        }

        public void Remove(Color color)
        {
            db.Colors.Remove(color);
            db.SaveChanges();
        }

        public void Edit(Color color)
        {
            db.Entry(color).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}