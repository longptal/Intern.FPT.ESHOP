using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ReceiptNote
    {
        public ReceiptNote()
        {
            ReceiptNoteLines = new HashSet<ReceiptNoteLine>();
        }

        public Guid Id { get; set; }
        public int ReceiptNoteNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Lock { get; set; }
        public string Title { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? SystemDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid EmployeeId { get; set; }
        public long Cx { get; set; }

        public Employee Employee { get; set; }
        public Supplier Supplier { get; set; }
        public WareHouse WareHouse { get; set; }
        public ICollection<ReceiptNoteLine> ReceiptNoteLines { get; set; }
    }
}
