using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ShipmentDetail
    {
        public ShipmentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public Guid CustomerId { get; set; }
        public long Cx { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
