using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment7.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Date")]
        public DateTime TestDate { get; set; }
        
        public Category Category { get; set; }
        
        [Display(Name="Amount of Questions")]
        public int AmountOfQuestions { get; set; }
        
        [Display(Name = "Amount of Right Answers")]
        public int AmountOfRightAnswers { get; set; }
    }

    public enum Category
    {
        Color,
        Animal,
        [Description("Punctuation Marks")]
        PunctuationMarks,
        Word,
        Calculus
    }
}