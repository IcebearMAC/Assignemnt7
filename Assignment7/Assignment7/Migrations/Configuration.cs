namespace Assignment7.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.EducationContext>
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

            context.Pictures.AddOrUpdate(p => p.ID,
                new Picture { ID = 1, AnimalName = "bat", PictureName="1.jpg" },
                new Picture { ID = 2, AnimalName = "bear", PictureName = "2.jpg" },
                new Picture { ID = 3, AnimalName = "cat", PictureName = "3.jpg" },
                new Picture { ID = 4, AnimalName = "chameleon", PictureName = "4.jpg" },
                new Picture { ID = 5, AnimalName = "dog", PictureName = "5.jpg" },
                new Picture { ID = 6, AnimalName = "dromedary", PictureName = "6.jpg" },
                new Picture { ID = 7, AnimalName = "elephant", PictureName = "7.jpg" },
                new Picture { ID = 8, AnimalName = "fennec", PictureName = "8.jpg" },
                new Picture { ID = 9, AnimalName = "fox", PictureName = "9.jpg" },
                new Picture { ID = 10, AnimalName = "giraffe", PictureName = "10.jpg" },
                new Picture { ID = 11, AnimalName = "hedgehog", PictureName = "11.jpg" },
                new Picture { ID = 12, AnimalName = "horse", PictureName = "12.png" },
                new Picture { ID = 13, AnimalName = "kangaroo", PictureName = "13.jpg" },
                new Picture { ID = 14, AnimalName = "koala", PictureName = "14.jpg" },
                new Picture { ID = 15, AnimalName = "lion", PictureName = "15.jpg" },
                new Picture { ID = 16, AnimalName = "monkey", PictureName = "16.jpg" },
                new Picture { ID = 17, AnimalName = "panda", PictureName = "17.jpg" },
                new Picture { ID = 18, AnimalName = "rabbit", PictureName = "18.jpg" },
                new Picture { ID = 19, AnimalName = "seahorse", PictureName = "19.jpg" },
                new Picture { ID = 20, AnimalName = "tiger", PictureName = "20.jpg" },
                new Picture { ID = 21, AnimalName = "turtle", PictureName = "21.jpg" },
                new Picture { ID = 22, AnimalName = "zebra", PictureName = "22.jpg" },
                new Picture { ID = 23, AnimalName = "camel", PictureName = "23.jpg" });

            context.Punctuations.AddOrUpdate(p => p.ID,
                new Punctuation { ID = 1, Text = "Example with full stop." },
                new Punctuation { ID = 2, Text = "Example, with comma" },
                new Punctuation { ID = 3, Text = "Example with a question mark isn't it?" },
                new Punctuation { ID = 4, Text = "Example with an exclamation mark damn it!" },
                new Punctuation { ID = 5, Text = "Example with a colon:" },
                new Punctuation { ID = 6, Text = "Example with a semicolon;" },
                new Punctuation { ID = 7, Text = "Example with both a comma and an exclamation mark, damn it!" },
                new Punctuation { ID = 8, Text = "Example with both a comma and an question mark, isn't it?" },
                new Punctuation { ID = 9, Text = "Call me Ishmael. Some years ago- never mind how long precisely- having little or no money in my purse, " +
                                                 "and nothing particular to interest me on shore, I thought I would sail about a little and see the watery part of the world. " +
                                                 "It is a way I have of driving off the spleen and regulating the circulation. Whenever I find myself growing grim about the mouth; " +
                                                 "whenever it is a damp, drizzly November in my soul; whenever I find myself involuntarily pausing before coffin warehouses, " +
                                                 "and bringing up the rear of every funeral I meet; and especially whenever my hypos get such an upper hand of me, " +
                                                 "that it requires a strong moral principle to prevent me from deliberately stepping into the street, and methodically knocking people's hats off- then, " +
                                                 "I account it high time to get to sea as soon as I can. This is my substitute for pistol and ball. " +
                                                 "With a philosophical flourish Cato throws himself upon his sword; I quietly take to the ship. There is nothing surprising in this. " +
                                                 "If they but knew it, almost all men in their degree, some time or other, cherish very nearly the same feelings towards the ocean with me." });

            context.Words.AddOrUpdate(p => p.Id,
                new Word {Id = 1, Words = "First example of sentence."},
                new Word { Id= 2 , Words = "Another example of sentence."}
                );

        }
    }
}
