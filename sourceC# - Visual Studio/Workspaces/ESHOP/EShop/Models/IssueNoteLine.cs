using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class IssueNoteLine
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Lock { get; set; }
        public Guid? IssueNoteId { get; set; }
        public Guid? ProductId { get; set; }
        public long Cx { get; set; }

        public IssueNote IssueNote { get; set; }
        public Product Product { get; set; }
    }
}
