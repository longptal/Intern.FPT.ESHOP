using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class InventoryCheckpoint : Base
    {
        public InventoryCheckpoint () : base(){}

        public InventoryCheckpoint (InventoryCheckpointEntity InventoryCheckpointEntity) : base(InventoryCheckpointEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is InventoryCheckpoint InventoryCheckpoint)
            {
                return Id.Equals(InventoryCheckpoint.Id);
            }

            return false;
        }
    }
}
