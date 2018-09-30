using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Tax : Base
    {
        public Tax () : base(){}

        public Tax (TaxEntity TaxEntity) : base(TaxEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Tax Tax)
            {
                return Id.Equals(Tax.Id);
            }

            return false;
        }
    }
}
