using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class WareHouse
    {
        public WareHouse()
        {
            Inventories = new HashSet<Inventory>();
            IssueNotes = new HashSet<IssueNote>();
            ReceiptNotes = new HashSet<ReceiptNote>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StorageLocation { get; set; }
        public bool IsDefault { get; set; }
        public long Cx { get; set; }
        public Guid StockkeeperId { get; set; }

        public Employee Stockkeeper { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<IssueNote> IssueNotes { get; set; }
        public ICollection<ReceiptNote> ReceiptNotes { get; set; }
    }
}
