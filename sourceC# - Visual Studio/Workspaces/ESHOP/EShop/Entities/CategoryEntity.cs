using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public Guid? ParentId { get; set; }
        public CategoryEntity ParentEntity { get; set; }
        public List<CategoryNameEntity> CategoryNameEntities { get; set; }
        public List<CategoryEntity> InverseParentEntities { get; set; }
        public List<ProductAttributeEntity> ProductAttributeEntities { get; set; }
        public List<ProductEntity> ProductEntities { get; set; }
        public List<TaxEntity> TaxEntities { get; set; }

        public CategoryEntity():base() { }

        public CategoryEntity(Category Category, params object[] args) :base(Category)
        {
		    foreach(object arg in args)
			{
                if (arg is Category Parent)
                    ParentEntity = new CategoryEntity(Parent);				
                if (arg is ICollection<CategoryName> CategoryNames)
                    CategoryNameEntities = CategoryNames.Select(model => new CategoryNameEntity(model, model.Language)).ToList();				
                if (arg is ICollection<Category> InverseParent)
                    InverseParentEntities = InverseParent.Select(model => new CategoryEntity(model)).ToList();				
                if (arg is ICollection<ProductAttribute> ProductAttributes)
                    ProductAttributeEntities = ProductAttributes.Select(model => new ProductAttributeEntity(model)).ToList();				
                if (arg is ICollection<Product> Products)
                    ProductEntities = Products.Select(model => new ProductEntity(model, model.Manufacturer)).ToList();				
                if (arg is ICollection<Tax> Taxes)
                    TaxEntities = Taxes.Select(model => new TaxEntity(model, model.Country)).ToList();				
			}
        }
    }

    public class CategorySearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public Guid? ParentId { get; set; }
    }
}
