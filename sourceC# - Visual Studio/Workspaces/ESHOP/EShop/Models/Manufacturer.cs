using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Origin { get; set; }
        public string TaxCode { get; set; }
        public bool IsActive { get; set; }
        public long Cx { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
