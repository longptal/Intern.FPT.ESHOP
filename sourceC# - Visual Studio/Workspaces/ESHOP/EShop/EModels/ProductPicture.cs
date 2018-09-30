using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductPicture : Base
    {
        public ProductPicture () : base(){}

        public ProductPicture (ProductPictureEntity ProductPictureEntity) : base(ProductPictureEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ProductPicture ProductPicture)
            {
                return Id.Equals(ProductPicture.Id);
            }

            return false;
        }
    }
}
