using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ProductPictureEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Path { get; set; }
        public Boolean IsDefault { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public ProductPictureEntity():base() { }

        public ProductPictureEntity(ProductPicture ProductPicture, params object[] args) :base(ProductPicture)
        {
		    foreach(object arg in args)
			{
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
			}
        }
    }

    public class ProductPictureSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Path { get; set; }
        public Boolean? IsDefault { get; set; }
        public Guid? ProductId { get; set; }
    }
}
