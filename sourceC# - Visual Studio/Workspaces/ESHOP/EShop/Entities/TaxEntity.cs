using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class TaxEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public Decimal Percentage { get; set; }
        public Guid CountryId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public CountryEntity CountryEntity { get; set; }

        public TaxEntity():base() { }

        public TaxEntity(Tax Tax, params object[] args) :base(Tax)
        {
		    foreach(object arg in args)
			{
                if (arg is Category Category)
                    CategoryEntity = new CategoryEntity(Category);				
                if (arg is Country Country)
                    CountryEntity = new CountryEntity(Country);				
			}
        }
    }

    public class TaxSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public Decimal? Percentage { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
