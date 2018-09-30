using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class InventoryCheckpointEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? InventoryId { get; set; }
        public Int32 Current { get; set; }
        public DateTime Date { get; set; }
        public InventoryEntity InventoryEntity { get; set; }

        public InventoryCheckpointEntity():base() { }

        public InventoryCheckpointEntity(InventoryCheckpoint InventoryCheckpoint, params object[] args) :base(InventoryCheckpoint)
        {
		    foreach(object arg in args)
			{
                if (arg is Inventory Inventory)
                    InventoryEntity = new InventoryEntity(Inventory);				
			}
        }
    }

    public class InventoryCheckpointSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? InventoryId { get; set; }
        public Int32? Current { get; set; }
        public DateTime? Date { get; set; }
    }
}
