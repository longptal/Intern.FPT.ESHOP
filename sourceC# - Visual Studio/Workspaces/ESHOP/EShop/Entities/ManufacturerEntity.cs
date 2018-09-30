using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ManufacturerEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Origin { get; set; }
        public String TaxCode { get; set; }
        public Boolean IsActive { get; set; }
        public List<ProductEntity> ProductEntities { get; set; }

        public ManufacturerEntity():base() { }

        public ManufacturerEntity(Manufacturer Manufacturer, params object[] args) :base(Manufacturer)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<Product> Products)
                    ProductEntities = Products.Select(model => new ProductEntity(model, model.Category)).ToList();				
			}
        }
    }

    public class ManufacturerSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Origin { get; set; }
        public String TaxCode { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
