using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Discount : Base
    {
        public Discount () : base(){}

        public Discount (DiscountEntity DiscountEntity) : base(DiscountEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Discount Discount)
            {
                return Id.Equals(Discount.Id);
            }

            return false;
        }
    }
}
