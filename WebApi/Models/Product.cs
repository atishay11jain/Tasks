using System;
using System.Collections.Generic;

namespace WebApi1.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? DescriptionPrd { get; set; }
        public int? Price { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? Rating { get; set; }
        public int? Stock { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public string? Thumbnail { get; set; }

       
    }
}
