using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ShipmentDetailEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String FullName { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Note { get; set; }
        public Guid CustomerId { get; set; }
        public CityEntity CityEntity { get; set; }
        public CountryEntity CountryEntity { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public List<OrderEntity> OrderEntities { get; set; }

        public ShipmentDetailEntity():base() { }

        public ShipmentDetailEntity(ShipmentDetail ShipmentDetail, params object[] args) :base(ShipmentDetail)
        {
		    foreach(object arg in args)
			{
                if (arg is City City)
                    CityEntity = new CityEntity(City);				
                if (arg is Country Country)
                    CountryEntity = new CountryEntity(Country);				
                if (arg is Customer Customer)
                    CustomerEntity = new CustomerEntity(Customer);				
                if (arg is ICollection<Order> Orders)
                    OrderEntities = Orders.Select(model => new OrderEntity(model, model.Customer)).ToList();				
			}
        }
    }

    public class ShipmentDetailSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String FullName { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Note { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
