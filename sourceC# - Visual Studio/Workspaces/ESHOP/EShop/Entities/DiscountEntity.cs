using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class DiscountEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Int32 Min { get; set; }
        public Int32 Max { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public DiscountEntity():base() { }

        public DiscountEntity(Discount Discount, params object[] args) :base(Discount)
        {
		    foreach(object arg in args)
			{
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
			}
        }
    }

    public class DiscountSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Int32? Min { get; set; }
        public Int32? Max { get; set; }
        public Guid? ProductId { get; set; }
    }
}
