using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ShipmentDetail : Base
    {

        public ShipmentDetail (ShipmentDetailEntity ShipmentDetailEntity) : base(ShipmentDetailEntity)
        {

			if (ShipmentDetailEntity.OrderEntities != null)
            {
                this.Orders = new HashSet<Order>();
                foreach (OrderEntity OrderEntity in ShipmentDetailEntity.OrderEntities)
                {
					OrderEntity.ShipmentDetailId = ShipmentDetailEntity.Id;
                    this.Orders.Add(new Order(OrderEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ShipmentDetail ShipmentDetail)
            {
                return Id.Equals(ShipmentDetail.Id);
            }

            return false;
        }
    }
}
