﻿using Assignment7.DataAccess;
using Assignment7.Models;
using Assignment7.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment7.Repositories
{
    public class ColorRepository
    {
        private EducationContext db = new EducationContext();

        public ColorScoreVM colorScore = new ColorScoreVM();

        public RandomColorsVM randomColors()
        {
            return new RandomColorsVM();
        }

        public Color Color(string Name)
        {
            return db.Colors.Where(c => c.Name == Name).First(); ;
        }

        public IEnumerable<Color> Colors()
        {
            return db.Colors;
        }

        public IEnumerable<Color> GetByType(System.Drawing.Color color)
        {
            return db.Colors.Where(c => c.Colors == color);
        }

        public IEnumerable<Color> Randomize()
        {
            List<Color> Colors = db.Colors.ToList();

            List<Color> RandomColors = new List<Color>();

            for (int i = 0; i < 4; i += 1)
            {
                Color randomColor = Colors[new Random().Next(0, Colors.Count)];
                RandomColors.Add(randomColor);
                Colors.Remove(randomColor);
            }

            randomColors().Color1 = RandomColors[0];
            randomColors().Color2 = RandomColors[1];
            randomColors().Color3 = RandomColors[2];
            randomColors().Color4 = RandomColors[3];

            return RandomColors;
        }

        public bool IsSame(List<Color> FirstList, List<Color> SecondList)
        {
            if (FirstList == null && SecondList == null)
                return true;

            if (FirstList == SecondList)
                return true;

            if (FirstList[0] == SecondList[0])
                return true;

            else return false;
        }

        public void CheckAnswer(int? choiceID, int? answerID)
        {
            if (choiceID == answerID)
            {
                colorScore.Score += 1;
                colorScore.NumOfQuestions += 1;
            }
            colorScore.NumOfQuestions += 1;
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