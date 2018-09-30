using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ReceiptNoteLine : Base
    {
        public ReceiptNoteLine () : base(){}

        public ReceiptNoteLine (ReceiptNoteLineEntity ReceiptNoteLineEntity) : base(ReceiptNoteLineEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ReceiptNoteLine ReceiptNoteLine)
            {
                return Id.Equals(ReceiptNoteLine.Id);
            }

            return false;
        }
    }
}
