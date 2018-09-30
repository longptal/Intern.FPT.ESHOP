using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class InventoryCheckpoint
    {
        public Guid Id { get; set; }
        public Guid? InventoryId { get; set; }
        public int Current { get; set; }
        public DateTime Date { get; set; }
        public long Cx { get; set; }

        public Inventory Inventory { get; set; }
    }
}
