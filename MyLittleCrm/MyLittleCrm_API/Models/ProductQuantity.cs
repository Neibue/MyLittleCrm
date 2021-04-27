using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleCramApi.Models
{
    public class ProductQuantity : Product
    {
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
