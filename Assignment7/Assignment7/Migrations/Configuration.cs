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

            context.Pictures.AddOrUpdate(p=>p.ID,
                new Picture { ID = 1, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\bat.jpg" },
                new Picture { ID = 2, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\bear.jpg" },
                new Picture { ID = 3, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\cat.jpg" },
                new Picture { ID = 4, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\chameleon.jpg" },
                new Picture { ID = 5, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\dog.jpg" },
                new Picture { ID = 6, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\dromadaire.jpg" },
                new Picture { ID = 7, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\elefant.jpg" },
                new Picture { ID = 8, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\fennec.jpg" },
                new Picture { ID = 9, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\fox.jpg" },
                new Picture { ID = 10, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\giraffe.jpg" },
                new Picture { ID = 11, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\hedgehog.jpg" },
                new Picture { ID = 12, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\horse.PNG" },
                new Picture { ID = 13, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\kangoroo.jpg" },
                new Picture { ID = 14, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\koala.jpg" },
                new Picture { ID = 15, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\lion.jpg" },
                new Picture { ID = 16, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\monkey.jpg" },
                new Picture { ID = 17, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\panda.jpg" },
                new Picture { ID = 18, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\pictures.txt" },
                new Picture { ID = 19, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\rabbit.jpg" },
                new Picture { ID = 20, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\seahorse.jpg" },
                new Picture { ID = 21, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\tiger.jpg" },
                new Picture { ID = 22, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\turtle.jpg" },
                new Picture { ID = 23, Path = "C:\\Users\\elevGr2\\Liam\\GitHub\\Repos\\Assignemnt7\\Assignment7\\Assignment7\\Pictures\\zebra.jpg" });

        }
    }
}
