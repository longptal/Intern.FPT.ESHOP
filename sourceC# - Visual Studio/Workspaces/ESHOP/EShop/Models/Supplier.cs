using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            ReceiptNotes = new HashSet<ReceiptNote>();
        }

        public Guid Id { get; set; }
        public string TaxCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Origin { get; set; }
        public bool IsActive { get; set; }
        public long Cx { get; set; }

        public ICollection<ReceiptNote> ReceiptNotes { get; set; }
    }
}
