using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class WareHouse : Base
    {

        public WareHouse (WareHouseEntity WareHouseEntity) : base(WareHouseEntity)
        {

			if (WareHouseEntity.InventoryEntities != null)
            {
                this.Inventories = new HashSet<Inventory>();
                foreach (InventoryEntity InventoryEntity in WareHouseEntity.InventoryEntities)
                {
					InventoryEntity.WareHouseId = WareHouseEntity.Id;
                    this.Inventories.Add(new Inventory(InventoryEntity));
                }
            }

			if (WareHouseEntity.IssueNoteEntities != null)
            {
                this.IssueNotes = new HashSet<IssueNote>();
                foreach (IssueNoteEntity IssueNoteEntity in WareHouseEntity.IssueNoteEntities)
                {
					IssueNoteEntity.WareHouseId = WareHouseEntity.Id;
                    this.IssueNotes.Add(new IssueNote(IssueNoteEntity));
                }
            }

			if (WareHouseEntity.ReceiptNoteEntities != null)
            {
                this.ReceiptNotes = new HashSet<ReceiptNote>();
                foreach (ReceiptNoteEntity ReceiptNoteEntity in WareHouseEntity.ReceiptNoteEntities)
                {
					ReceiptNoteEntity.WareHouseId = WareHouseEntity.Id;
                    this.ReceiptNotes.Add(new ReceiptNote(ReceiptNoteEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is WareHouse WareHouse)
            {
                return Id.Equals(WareHouse.Id);
            }

            return false;
        }
    }
}
