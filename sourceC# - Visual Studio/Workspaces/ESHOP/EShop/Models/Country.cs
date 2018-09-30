using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            ShipmentDetails = new HashSet<ShipmentDetail>();
            Taxes = new HashSet<Tax>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public long Cx { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetails { get; set; }
        public ICollection<Tax> Taxes { get; set; }
    }
}
