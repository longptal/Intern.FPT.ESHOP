using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ProductAttributeEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public List<ProductAttributeNameEntity> ProductAttributeNameEntities { get; set; }
        public List<ProductValueEntity> ProductValueEntities { get; set; }

        public ProductAttributeEntity():base() { }

        public ProductAttributeEntity(ProductAttribute ProductAttribute, params object[] args) :base(ProductAttribute)
        {
		    foreach(object arg in args)
			{
                if (arg is Category Category)
                    CategoryEntity = new CategoryEntity(Category);				
                if (arg is ICollection<ProductAttributeName> ProductAttributeNames)
                    ProductAttributeNameEntities = ProductAttributeNames.Select(model => new ProductAttributeNameEntity(model, model.Language)).ToList();				
                if (arg is ICollection<ProductValue> ProductValues)
                    ProductValueEntities = ProductValues.Select(model => new ProductValueEntity(model, model.Language, model.Product)).ToList();				
			}
        }
    }

    public class ProductAttributeSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
