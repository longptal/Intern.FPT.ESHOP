using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class IssueNote
    {
        public IssueNote()
        {
            IssueNoteLines = new HashSet<IssueNoteLine>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid WareHouseId { get; set; }
        public bool Lock { get; set; }
        public long Cx { get; set; }

        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }
        public WareHouse WareHouse { get; set; }
        public ICollection<IssueNoteLine> IssueNoteLines { get; set; }
    }
}
