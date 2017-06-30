using System.ComponentModel.DataAnnotations;

namespace Assignment7.Models
{
    public class Picture
    {
        [Key]
        public int ID { get; set; }
        public string Path { get; set; }
    }
}