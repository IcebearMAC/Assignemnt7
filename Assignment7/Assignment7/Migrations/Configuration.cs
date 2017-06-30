namespace Assignment7.Migrations
{
    using Assignment7.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment7.DataAccess.EducationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment7.DataAccess.EducationContext context)
        {
            context.Colors.AddOrUpdate(c => c.ID,
                new Color { ID = 1, Name = "Red", Colors = System.Drawing.Color.Red },
                new Color { ID = 2, Name = "Orange", Colors = System.Drawing.Color.Orange },
                new Color { ID = 3, Name = "Yellow", Colors = System.Drawing.Color.Yellow },
                new Color { ID = 4, Name = "Green", Colors = System.Drawing.Color.Green },
                new Color { ID = 5, Name = "Blue", Colors = System.Drawing.Color.Blue },
                new Color { ID = 6, Name = "Indigo", Colors = System.Drawing.Color.Indigo },
                new Color { ID = 7, Name = "Violet", Colors = System.Drawing.Color.Violet });
        }
    }
}
