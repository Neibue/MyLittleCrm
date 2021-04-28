using System.Collections.Generic;

namespace MyLittleCrmApi.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Address { get; set; }
        public double Benefits { get; set; }
        public string SiretNumber { get; set; }
        public string TaxRegistration { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}