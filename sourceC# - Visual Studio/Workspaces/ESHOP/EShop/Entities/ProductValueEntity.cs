using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ProductValueEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Value { get; set; }
        public Guid ProductId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid AttributeId { get; set; }
        public ProductAttributeEntity AttributeEntity { get; set; }
        public LanguageEntity LanguageEntity { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public ProductValueEntity():base() { }

        public ProductValueEntity(ProductValue ProductValue, params object[] args) :base(ProductValue)
        {
		    foreach(object arg in args)
			{
                if (arg is ProductAttribute Attribute)
                    AttributeEntity = new ProductAttributeEntity(Attribute);				
                if (arg is Language Language)
                    LanguageEntity = new LanguageEntity(Language);				
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
			}
        }
    }

    public class ProductValueSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Value { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? AttributeId { get; set; }
    }
}
