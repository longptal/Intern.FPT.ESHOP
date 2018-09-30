using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }
        public bool OnPaid { get; set; }
        public string Method { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShipmentDetailId { get; set; }
        public long Cx { get; set; }

        public Customer Customer { get; set; }
        public ShipmentDetail ShipmentDetail { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
