using System;
using System.Collections.Generic;

namespace MyLittleCramApi.Models
{
    public class Quote
    {
        public string Reference { get; set; }
        public DateTime DateCreated { get; set; }
        public User Commercial { get; set; }
        public List<Product> Products { get; set; }
        public string Type { get; set; }
        public Contact Contact { get; set; }

    }
}