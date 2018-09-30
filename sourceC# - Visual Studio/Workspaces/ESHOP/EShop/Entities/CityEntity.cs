using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CityEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public CountryEntity CountryEntity { get; set; }
        public List<ShipmentDetailEntity> ShipmentDetailEntities { get; set; }

        public CityEntity():base() { }

        public CityEntity(City City, params object[] args) :base(City)
        {
		    foreach(object arg in args)
			{
                if (arg is Country Country)
                    CountryEntity = new CountryEntity(Country);				
                if (arg is ICollection<ShipmentDetail> ShipmentDetails)
                    ShipmentDetailEntities = ShipmentDetails.Select(model => new ShipmentDetailEntity(model, model.Country, model.Customer)).ToList();				
			}
        }
    }

    public class CitySearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? CountryId { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
    }
}
