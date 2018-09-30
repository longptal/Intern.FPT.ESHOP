using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductAttributeName : Base
    {
        public ProductAttributeName () : base(){}

        public ProductAttributeName (ProductAttributeNameEntity ProductAttributeNameEntity) : base(ProductAttributeNameEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ProductAttributeName ProductAttributeName)
            {
                return Id.Equals(ProductAttributeName.Id);
            }

            return false;
        }
    }
}
