namespace MyLittleCramApi.Models
{
    public class Company
    {
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public double Benefits { get; set; }
        public string SiretNumber { get; set; }
        public string TaxRegistration { get; set; }
    }
}