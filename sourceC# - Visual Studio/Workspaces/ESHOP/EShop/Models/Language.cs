using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Language
    {
        public Language()
        {
            CategoryNames = new HashSet<CategoryName>();
            ProductAttributeNames = new HashSet<ProductAttributeName>();
            ProductValues = new HashSet<ProductValue>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public long Cx { get; set; }

        public ICollection<CategoryName> CategoryNames { get; set; }
        public ICollection<ProductAttributeName> ProductAttributeNames { get; set; }
        public ICollection<ProductValue> ProductValues { get; set; }
    }
}
