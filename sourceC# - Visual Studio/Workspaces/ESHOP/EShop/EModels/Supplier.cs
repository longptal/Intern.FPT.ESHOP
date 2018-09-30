using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Supplier : Base
    {

        public Supplier (SupplierEntity SupplierEntity) : base(SupplierEntity)
        {

			if (SupplierEntity.ReceiptNoteEntities != null)
            {
                this.ReceiptNotes = new HashSet<ReceiptNote>();
                foreach (ReceiptNoteEntity ReceiptNoteEntity in SupplierEntity.ReceiptNoteEntities)
                {
					ReceiptNoteEntity.SupplierId = SupplierEntity.Id;
                    this.ReceiptNotes.Add(new ReceiptNote(ReceiptNoteEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Supplier Supplier)
            {
                return Id.Equals(Supplier.Id);
            }

            return false;
        }
    }
}
