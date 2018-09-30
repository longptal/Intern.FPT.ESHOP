using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CountryEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Note { get; set; }
        public List<CityEntity> CityEntities { get; set; }
        public List<ShipmentDetailEntity> ShipmentDetailEntities { get; set; }
        public List<TaxEntity> TaxEntities { get; set; }

        public CountryEntity():base() { }

        public CountryEntity(Country Country, params object[] args) :base(Country)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<City> Cities)
                    CityEntities = Cities.Select(model => new CityEntity(model)).ToList();				
                if (arg is ICollection<ShipmentDetail> ShipmentDetails)
                    ShipmentDetailEntities = ShipmentDetails.Select(model => new ShipmentDetailEntity(model, model.City, model.Customer)).ToList();				
                if (arg is ICollection<Tax> Taxes)
                    TaxEntities = Taxes.Select(model => new TaxEntity(model, model.Category)).ToList();				
			}
        }
    }

    public class CountrySearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Note { get; set; }
    }
}
