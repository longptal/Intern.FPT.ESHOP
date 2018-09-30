using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Discount
    {
        public Guid Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Guid ProductId { get; set; }
        public long Cx { get; set; }

        public Product Product { get; set; }
    }
}
