using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment7.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }
        public DateTime TestDate { get; set; }
        public Category Category { get; set; }
        [Display(Name="Amount of Questions")]
        public int AmountOfQuestions { get; set; }
        [Display(Name = "Amount of Right Answers")]
        public int AmountOfRightAnswer { get; set; }
    }

    public enum Category
    {
        Color,
        Animal,
        Text
    }
}