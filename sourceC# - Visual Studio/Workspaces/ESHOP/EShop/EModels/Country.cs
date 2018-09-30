using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Country : Base
    {

        public Country (CountryEntity CountryEntity) : base(CountryEntity)
        {

			if (CountryEntity.CityEntities != null)
            {
                this.Cities = new HashSet<City>();
                foreach (CityEntity CityEntity in CountryEntity.CityEntities)
                {
					CityEntity.CountryId = CountryEntity.Id;
                    this.Cities.Add(new City(CityEntity));
                }
            }

			if (CountryEntity.ShipmentDetailEntities != null)
            {
                this.ShipmentDetails = new HashSet<ShipmentDetail>();
                foreach (ShipmentDetailEntity ShipmentDetailEntity in CountryEntity.ShipmentDetailEntities)
                {
					ShipmentDetailEntity.CountryId = CountryEntity.Id;
                    this.ShipmentDetails.Add(new ShipmentDetail(ShipmentDetailEntity));
                }
            }

			if (CountryEntity.TaxEntities != null)
            {
                this.Taxes = new HashSet<Tax>();
                foreach (TaxEntity TaxEntity in CountryEntity.TaxEntities)
                {
					TaxEntity.CountryId = CountryEntity.Id;
                    this.Taxes.Add(new Tax(TaxEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Country Country)
            {
                return Id.Equals(Country.Id);
            }

            return false;
        }
    }
}
