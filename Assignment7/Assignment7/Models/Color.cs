using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Models
{
    public class Color
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public System.Drawing.Color Colors { get; set; }
    }
}