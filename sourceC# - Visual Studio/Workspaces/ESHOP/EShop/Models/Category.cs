using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryNames = new HashSet<CategoryName>();
            InverseParent = new HashSet<Category>();
            ProductAttributes = new HashSet<ProductAttribute>();
            Products = new HashSet<Product>();
            Taxes = new HashSet<Tax>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid? ParentId { get; set; }
        public long Cx { get; set; }

        public Category Parent { get; set; }
        public ICollection<CategoryName> CategoryNames { get; set; }
        public ICollection<Category> InverseParent { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Tax> Taxes { get; set; }
    }
}
