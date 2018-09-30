using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductValue : Base
    {
        public ProductValue () : base(){}

        public ProductValue (ProductValueEntity ProductValueEntity) : base(ProductValueEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ProductValue ProductValue)
            {
                return Id.Equals(ProductValue.Id);
            }

            return false;
        }
    }
}
