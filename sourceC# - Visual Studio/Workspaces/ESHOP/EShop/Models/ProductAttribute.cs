using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            ProductAttributeNames = new HashSet<ProductAttributeName>();
            ProductValues = new HashSet<ProductValue>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid CategoryId { get; set; }
        public long Cx { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductAttributeName> ProductAttributeNames { get; set; }
        public ICollection<ProductValue> ProductValues { get; set; }
    }
}
