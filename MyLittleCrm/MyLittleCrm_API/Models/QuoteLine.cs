namespace MyLittleCramApi.Models
{
    public class QuoteLine
    {
        public int QuoteLineID { get; set; }
        public int Quantity { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int QuoteID { get; set; }
        public Quote Quote { get; set; }
    }
}