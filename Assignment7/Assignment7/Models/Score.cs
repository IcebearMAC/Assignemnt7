using System.ComponentModel.DataAnnotations;

namespace Assignment7.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }
        public Category Category { get; set; }
        public int AmountOfQuestions { get; set; }
        public int AmountOfRightAnswer { get; set; }
    }

    public enum Category
    {
        Color,
        Animal,
        Text
    }
}