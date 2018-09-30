using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Inputs = new HashSet<Input>();
            InventoryCheckpoints = new HashSet<InventoryCheckpoint>();
            Outputs = new HashSet<Output>();
        }

        public Guid Id { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long Cx { get; set; }

        public Product Product { get; set; }
        public WareHouse WareHouse { get; set; }
        public ICollection<Input> Inputs { get; set; }
        public ICollection<InventoryCheckpoint> InventoryCheckpoints { get; set; }
        public ICollection<Output> Outputs { get; set; }
    }
}
