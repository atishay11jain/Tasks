using System;
using System.Collections.Generic;

namespace WebApi1.Models
{
    public partial class PrdImage
    {
        public int? PrdId { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }

        public virtual Product? Prd { get; set; }
    }
}
