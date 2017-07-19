using System.ComponentModel.DataAnnotations;

namespace Assignment7.Models
{
    public class Punctuation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }
    }
}