using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ReceiptNote : Base
    {

        public ReceiptNote (ReceiptNoteEntity ReceiptNoteEntity) : base(ReceiptNoteEntity)
        {

			if (ReceiptNoteEntity.ReceiptNoteLineEntities != null)
            {
                this.ReceiptNoteLines = new HashSet<ReceiptNoteLine>();
                foreach (ReceiptNoteLineEntity ReceiptNoteLineEntity in ReceiptNoteEntity.ReceiptNoteLineEntities)
                {
					ReceiptNoteLineEntity.ReceiptNoteId = ReceiptNoteEntity.Id;
                    this.ReceiptNoteLines.Add(new ReceiptNoteLine(ReceiptNoteLineEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ReceiptNote ReceiptNote)
            {
                return Id.Equals(ReceiptNote.Id);
            }

            return false;
        }
    }
}
