using System.Collections.Generic;

namespace MyLittleCrmApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Reference { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ICollection<Quote> Quotes { get; set; }
        public List<QuoteLine> QuoteLines { get; set; }
    }
}