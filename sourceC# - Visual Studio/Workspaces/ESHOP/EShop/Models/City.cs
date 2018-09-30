using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class City
    {
        public City()
        {
            ShipmentDetails = new HashSet<ShipmentDetail>();
        }

        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Cx { get; set; }

        public Country Country { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetails { get; set; }
    }
}
