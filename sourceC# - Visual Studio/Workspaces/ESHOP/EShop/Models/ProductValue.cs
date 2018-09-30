using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductValue
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid ProductId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid AttributeId { get; set; }
        public long Cx { get; set; }

        public ProductAttribute Attribute { get; set; }
        public Language Language { get; set; }
        public Product Product { get; set; }
    }
}
