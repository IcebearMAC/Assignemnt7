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
    }
}