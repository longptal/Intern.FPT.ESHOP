using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            IssueNotes = new HashSet<IssueNote>();
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Number { get; set; }
        public string Seri { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long Cx { get; set; }

        public Order Order { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public ICollection<IssueNote> IssueNotes { get; set; }
    }
}
