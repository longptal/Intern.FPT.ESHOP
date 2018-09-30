using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class CustomerGroup
    {
        public CustomerGroup()
        {
            Customers = new HashSet<Customer>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long Cx { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
