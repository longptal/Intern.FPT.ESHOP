using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ProductAttributeName
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LanguageId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public long Cx { get; set; }

        public Language Language { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}
