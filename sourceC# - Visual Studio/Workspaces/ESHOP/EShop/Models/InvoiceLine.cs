using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class InvoiceLine
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int? Quantity { get; set; }
        public long Cx { get; set; }

        public Invoice Invoice { get; set; }
    }
}
