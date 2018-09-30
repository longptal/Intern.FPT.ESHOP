using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class PackEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 Quantity { get; set; }
        public Boolean IsDefault { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }
        public List<OrderDetailEntity> OrderDetailEntities { get; set; }

        public PackEntity():base() { }

        public PackEntity(Pack Pack, params object[] args) :base(Pack)
        {
		    foreach(object arg in args)
			{
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
                if (arg is ICollection<OrderDetail> OrderDetails)
                    OrderDetailEntities = OrderDetails.Select(model => new OrderDetailEntity(model, model.Order)).ToList();				
			}
        }
    }

    public class PackSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Decimal? UnitPrice { get; set; }
        public Int32? Quantity { get; set; }
        public Boolean? IsDefault { get; set; }
        public Guid? ProductId { get; set; }
    }
}
