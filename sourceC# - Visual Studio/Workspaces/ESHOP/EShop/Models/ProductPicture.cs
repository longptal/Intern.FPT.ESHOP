using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductPicture
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public bool IsDefault { get; set; }
        public Guid ProductId { get; set; }
        public long Cx { get; set; }

        public Product Product { get; set; }
    }
}
