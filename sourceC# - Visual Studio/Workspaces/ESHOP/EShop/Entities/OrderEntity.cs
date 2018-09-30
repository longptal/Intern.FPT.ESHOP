using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class OrderEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 Status { get; set; }
        public Decimal Total { get; set; }
        public Boolean OnPaid { get; set; }
        public String Method { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShipmentDetailId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public ShipmentDetailEntity ShipmentDetailEntity { get; set; }
        public List<InvoiceEntity> InvoiceEntities { get; set; }
        public List<OrderDetailEntity> OrderDetailEntities { get; set; }

        public OrderEntity():base() { }

        public OrderEntity(Order Order, params object[] args) :base(Order)
        {
		    foreach(object arg in args)
			{
                if (arg is Customer Customer)
                    CustomerEntity = new CustomerEntity(Customer);				
                if (arg is ShipmentDetail ShipmentDetail)
                    ShipmentDetailEntity = new ShipmentDetailEntity(ShipmentDetail);				
                if (arg is ICollection<Invoice> Invoices)
                    InvoiceEntities = Invoices.Select(model => new InvoiceEntity(model)).ToList();				
                if (arg is ICollection<OrderDetail> OrderDetails)
                    OrderDetailEntities = OrderDetails.Select(model => new OrderDetailEntity(model, model.Pack)).ToList();				
			}
        }
    }

    public class OrderSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Int32? Status { get; set; }
        public Decimal? Total { get; set; }
        public Boolean? OnPaid { get; set; }
        public String Method { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ShipmentDetailId { get; set; }
    }
}
