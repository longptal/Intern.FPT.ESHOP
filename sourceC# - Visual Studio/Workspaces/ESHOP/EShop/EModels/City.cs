using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class City : Base
    {

        public City (CityEntity CityEntity) : base(CityEntity)
        {

			if (CityEntity.ShipmentDetailEntities != null)
            {
                this.ShipmentDetails = new HashSet<ShipmentDetail>();
                foreach (ShipmentDetailEntity ShipmentDetailEntity in CityEntity.ShipmentDetailEntities)
                {
					ShipmentDetailEntity.CityId = CityEntity.Id;
                    this.ShipmentDetails.Add(new ShipmentDetail(ShipmentDetailEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is City City)
            {
                return Id.Equals(City.Id);
            }

            return false;
        }
    }
}
