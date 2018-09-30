using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Output
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid InventoryId { get; set; }
        public long Cx { get; set; }

        public Inventory Inventory { get; set; }
    }
}
