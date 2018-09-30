using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Pack
    {
        public Pack()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDefault { get; set; }
        public Guid ProductId { get; set; }
        public long Cx { get; set; }

        public Product Product { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
