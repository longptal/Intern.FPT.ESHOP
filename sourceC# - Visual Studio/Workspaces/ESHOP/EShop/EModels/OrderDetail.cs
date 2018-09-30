using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class OrderDetail : Base
    {
        public OrderDetail () : base(){}

        public OrderDetail (OrderDetailEntity OrderDetailEntity) : base(OrderDetailEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is OrderDetail OrderDetail)
            {
                return Id.Equals(OrderDetail.Id);
            }

            return false;
        }
    }
}
