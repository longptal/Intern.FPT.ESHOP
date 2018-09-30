using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class InvoiceLine : Base
    {
        public InvoiceLine () : base(){}

        public InvoiceLine (InvoiceLineEntity InvoiceLineEntity) : base(InvoiceLineEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is InvoiceLine InvoiceLine)
            {
                return Id.Equals(InvoiceLine.Id);
            }

            return false;
        }
    }
}
