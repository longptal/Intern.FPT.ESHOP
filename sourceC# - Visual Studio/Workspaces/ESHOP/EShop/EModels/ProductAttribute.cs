using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductAttribute : Base
    {

        public ProductAttribute (ProductAttributeEntity ProductAttributeEntity) : base(ProductAttributeEntity)
        {

			if (ProductAttributeEntity.ProductAttributeNameEntities != null)
            {
                this.ProductAttributeNames = new HashSet<ProductAttributeName>();
                foreach (ProductAttributeNameEntity ProductAttributeNameEntity in ProductAttributeEntity.ProductAttributeNameEntities)
                {
					ProductAttributeNameEntity.ProductAttributeId = ProductAttributeEntity.Id;
                    this.ProductAttributeNames.Add(new ProductAttributeName(ProductAttributeNameEntity));
                }
            }

			if (ProductAttributeEntity.ProductValueEntities != null)
            {
                this.ProductValues = new HashSet<ProductValue>();
                foreach (ProductValueEntity ProductValueEntity in ProductAttributeEntity.ProductValueEntities)
                {
					ProductValueEntity.AttributeId = ProductAttributeEntity.Id;
                    this.ProductValues.Add(new ProductValue(ProductValueEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ProductAttribute ProductAttribute)
            {
                return Id.Equals(ProductAttribute.Id);
            }

            return false;
        }
    }
}
