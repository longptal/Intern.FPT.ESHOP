using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Pack : Base
    {

        public Pack (PackEntity PackEntity) : base(PackEntity)
        {

			if (PackEntity.OrderDetailEntities != null)
            {
                this.OrderDetails = new HashSet<OrderDetail>();
                foreach (OrderDetailEntity OrderDetailEntity in PackEntity.OrderDetailEntities)
                {
					OrderDetailEntity.PackId = PackEntity.Id;
                    this.OrderDetails.Add(new OrderDetail(OrderDetailEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Pack Pack)
            {
                return Id.Equals(Pack.Id);
            }

            return false;
        }
    }
}
