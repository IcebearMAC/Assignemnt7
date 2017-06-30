using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Models
{
    public class Punctuation
    {
        [Key]
        public int ID { get; set; }
        public string Text { get; set; }
    }
}