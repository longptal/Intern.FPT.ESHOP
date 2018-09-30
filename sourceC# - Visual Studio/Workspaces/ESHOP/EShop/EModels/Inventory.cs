using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Inventory : Base
    {

        public Inventory (InventoryEntity InventoryEntity) : base(InventoryEntity)
        {

			if (InventoryEntity.InputEntities != null)
            {
                this.Inputs = new HashSet<Input>();
                foreach (InputEntity InputEntity in InventoryEntity.InputEntities)
                {
					InputEntity.InventoryId = InventoryEntity.Id;
                    this.Inputs.Add(new Input(InputEntity));
                }
            }

			if (InventoryEntity.InventoryCheckpointEntities != null)
            {
                this.InventoryCheckpoints = new HashSet<InventoryCheckpoint>();
                foreach (InventoryCheckpointEntity InventoryCheckpointEntity in InventoryEntity.InventoryCheckpointEntities)
                {
					InventoryCheckpointEntity.InventoryId = InventoryEntity.Id;
                    this.InventoryCheckpoints.Add(new InventoryCheckpoint(InventoryCheckpointEntity));
                }
            }

			if (InventoryEntity.OutputEntities != null)
            {
                this.Outputs = new HashSet<Output>();
                foreach (OutputEntity OutputEntity in InventoryEntity.OutputEntities)
                {
					OutputEntity.InventoryId = InventoryEntity.Id;
                    this.Outputs.Add(new Output(OutputEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Inventory Inventory)
            {
                return Id.Equals(Inventory.Id);
            }

            return false;
        }
    }
}
