using Assignment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment7.ViewModels
{
    public class RandomColorsVM
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
        public Color Color4 { get; set; }
        public int Count { get; set; }

        public Color Answer { get; set; }
        public Color Choice { get; set; }
    }
}