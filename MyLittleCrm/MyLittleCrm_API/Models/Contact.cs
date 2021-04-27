using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleCramApi.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public List<Quote> Quotes { get; set; }
    }
}
