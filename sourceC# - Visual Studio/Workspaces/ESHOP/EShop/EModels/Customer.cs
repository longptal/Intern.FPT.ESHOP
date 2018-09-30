using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Customer : Base
    {

        public Customer (CustomerEntity CustomerEntity) : base(CustomerEntity)
        {

			if (CustomerEntity.IssueNoteEntities != null)
            {
                this.IssueNotes = new HashSet<IssueNote>();
                foreach (IssueNoteEntity IssueNoteEntity in CustomerEntity.IssueNoteEntities)
                {
					IssueNoteEntity.CustomerId = CustomerEntity.Id;
                    this.IssueNotes.Add(new IssueNote(IssueNoteEntity));
                }
            }

			if (CustomerEntity.OrderEntities != null)
            {
                this.Orders = new HashSet<Order>();
                foreach (OrderEntity OrderEntity in CustomerEntity.OrderEntities)
                {
					OrderEntity.CustomerId = CustomerEntity.Id;
                    this.Orders.Add(new Order(OrderEntity));
                }
            }

			if (CustomerEntity.ShipmentDetailEntities != null)
            {
                this.ShipmentDetails = new HashSet<ShipmentDetail>();
                foreach (ShipmentDetailEntity ShipmentDetailEntity in CustomerEntity.ShipmentDetailEntities)
                {
					ShipmentDetailEntity.CustomerId = CustomerEntity.Id;
                    this.ShipmentDetails.Add(new ShipmentDetail(ShipmentDetailEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Customer Customer)
            {
                return Id.Equals(Customer.Id);
            }

            return false;
        }
    }
}
