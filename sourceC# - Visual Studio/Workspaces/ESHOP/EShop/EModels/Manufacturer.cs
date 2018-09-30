using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Manufacturer : Base
    {

        public Manufacturer (ManufacturerEntity ManufacturerEntity) : base(ManufacturerEntity)
        {

			if (ManufacturerEntity.ProductEntities != null)
            {
                this.Products = new HashSet<Product>();
                foreach (ProductEntity ProductEntity in ManufacturerEntity.ProductEntities)
                {
					ProductEntity.ManufacturerId = ManufacturerEntity.Id;
                    this.Products.Add(new Product(ProductEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Manufacturer Manufacturer)
            {
                return Id.Equals(Manufacturer.Id);
            }

            return false;
        }
    }
}
