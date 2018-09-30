using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class LanguageEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Icon { get; set; }
        public Boolean IsActive { get; set; }
        public List<CategoryNameEntity> CategoryNameEntities { get; set; }
        public List<ProductAttributeNameEntity> ProductAttributeNameEntities { get; set; }
        public List<ProductValueEntity> ProductValueEntities { get; set; }

        public LanguageEntity():base() { }

        public LanguageEntity(Language Language, params object[] args) :base(Language)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<CategoryName> CategoryNames)
                    CategoryNameEntities = CategoryNames.Select(model => new CategoryNameEntity(model, model.Category)).ToList();				
                if (arg is ICollection<ProductAttributeName> ProductAttributeNames)
                    ProductAttributeNameEntities = ProductAttributeNames.Select(model => new ProductAttributeNameEntity(model, model.ProductAttribute)).ToList();				
                if (arg is ICollection<ProductValue> ProductValues)
                    ProductValueEntities = ProductValues.Select(model => new ProductValueEntity(model, model.Attribute, model.Product)).ToList();				
			}
        }
    }

    public class LanguageSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Icon { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
