using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment7.DataAccess
{
    public class EducationContext : DbContext
    {
        public EducationContext() : base("DefaultConnection") { }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Score> Scores { get; set; }

        public DbSet<Punctuation> Punctuations { get; set; }

//        public DbSet<Calculus> Caclulus { get; set; }

        //public System.Data.Entity.DbSet<Assignment7.Models.Calculus> Calculus { get; set; }
    }
}