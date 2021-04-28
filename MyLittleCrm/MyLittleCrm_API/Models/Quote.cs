using System;
using System.Collections.Generic;

namespace MyLittleCrmApi.Models
{
    public class Quote
    {
        public int QuoteID { get; set; }
        public int CommercialID { get; set; }
        public int ContactID { get; set; }
        public string Reference { get; set; }
        public DateTime DateCreated { get; set; }
        public string Type { get; set; }
        public Contact Contact { get; set; }

        public ICollection<Product> Products { get; set; }
        public List<QuoteLine> QuoteLines { get; set; }
    }
}