using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ProductAttributeNameEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid LanguageId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public LanguageEntity LanguageEntity { get; set; }
        public ProductAttributeEntity ProductAttributeEntity { get; set; }

        public ProductAttributeNameEntity():base() { }

        public ProductAttributeNameEntity(ProductAttributeName ProductAttributeName, params object[] args) :base(ProductAttributeName)
        {
		    foreach(object arg in args)
			{
                if (arg is Language Language)
                    LanguageEntity = new LanguageEntity(Language);				
                if (arg is ProductAttribute ProductAttribute)
                    ProductAttributeEntity = new ProductAttributeEntity(ProductAttribute);				
			}
        }
    }

    public class ProductAttributeNameSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? ProductAttributeId { get; set; }
    }
}
