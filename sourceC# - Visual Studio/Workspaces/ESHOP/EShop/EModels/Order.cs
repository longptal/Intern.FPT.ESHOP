using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Order : Base
    {

        public Order (OrderEntity OrderEntity) : base(OrderEntity)
        {

			if (OrderEntity.InvoiceEntities != null)
            {
                this.Invoices = new HashSet<Invoice>();
                foreach (InvoiceEntity InvoiceEntity in OrderEntity.InvoiceEntities)
                {
					InvoiceEntity.OrderId = OrderEntity.Id;
                    this.Invoices.Add(new Invoice(InvoiceEntity));
                }
            }

			if (OrderEntity.OrderDetailEntities != null)
            {
                this.OrderDetails = new HashSet<OrderDetail>();
                foreach (OrderDetailEntity OrderDetailEntity in OrderEntity.OrderDetailEntities)
                {
					OrderDetailEntity.OrderId = OrderEntity.Id;
                    this.OrderDetails.Add(new OrderDetail(OrderDetailEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Order Order)
            {
                return Id.Equals(Order.Id);
            }

            return false;
        }
    }
}
