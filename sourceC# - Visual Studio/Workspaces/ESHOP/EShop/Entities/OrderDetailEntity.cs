using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class OrderDetailEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Decimal Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid PackId { get; set; }
        public OrderEntity OrderEntity { get; set; }
        public PackEntity PackEntity { get; set; }

        public OrderDetailEntity():base() { }

        public OrderDetailEntity(OrderDetail OrderDetail, params object[] args) :base(OrderDetail)
        {
		    foreach(object arg in args)
			{
                if (arg is Order Order)
                    OrderEntity = new OrderEntity(Order);				
                if (arg is Pack Pack)
                    PackEntity = new PackEntity(Pack);				
			}
        }
    }

    public class OrderDetailSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Decimal? Quantity { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? PackId { get; set; }
    }
}
