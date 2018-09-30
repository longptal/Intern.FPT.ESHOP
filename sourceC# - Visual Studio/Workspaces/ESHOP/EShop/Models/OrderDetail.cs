using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid PackId { get; set; }
        public long Cx { get; set; }

        public Order Order { get; set; }
        public Pack Pack { get; set; }
    }
}
