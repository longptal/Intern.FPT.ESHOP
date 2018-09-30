using EShop.Entities;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.MAdmin.MCountry
{
    public interface ICountryValidator : IValidator<CountryEntity>, ITransientService { }
    public class CountryValidator : CommonValidator, ICountryValidator
    {
        public CountryValidator(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public bool ValidateCreate(CountryEntity CountryEntity)
        {
            IsValid = true;
            if (string.IsNullOrEmpty(CountryEntity.Code))
                CountryEntity.AddError(nameof(CountryEntity.Code), "Must fill data.");
            if (CountryEntity.Errors.Count > 0) IsValid = false;
            if (CountryEntity.CityEntities != null)
                foreach (CityEntity CityEntity in CountryEntity.CityEntities)
                {
                    if (string.IsNullOrEmpty(CityEntity.Code))
                        CityEntity.AddError(nameof(CityEntity.Code), "Must fill data.");
                    if (string.IsNullOrEmpty(CityEntity.Name))
                        CityEntity.AddError(nameof(CityEntity.Name), "Must fill data.");
                    if (CityEntity.Errors.Count > 0) IsValid = false;
                }
            if (CountryEntity.TaxEntities != null)
                foreach (TaxEntity TaxEntity in CountryEntity.TaxEntities)
                {
                    if (string.IsNullOrEmpty(TaxEntity.Code))
                        TaxEntity.AddError(nameof(TaxEntity.Code), "Must fill data.");
                    if (TaxEntity.Errors.Count > 0) IsValid = false;
                }
            return IsValid;
        }

        public bool ValidateUpdate(CountryEntity CountryEntity)
        {
            IsValid = true;
            Country Country = UnitOfWork.CountryRepository.Get(CountryEntity.Id);
            if (Country == null)
                CountryEntity.AddError(nameof(CountryEntity.Id), "Item doesn't existed.");
            if (string.IsNullOrEmpty(CountryEntity.Code))
                CountryEntity.AddError(nameof(CountryEntity.Code), "Must fill data.");
            if (CountryEntity.Errors.Count > 0) IsValid = false;

            if (CountryEntity.CityEntities != null)
                foreach (CityEntity CityEntity in CountryEntity.CityEntities)
                {
                    if (string.IsNullOrEmpty(CityEntity.Code))
                        CityEntity.AddError(nameof(CityEntity.Code), "Must fill data.");
                    if (string.IsNullOrEmpty(CityEntity.Name))
                        CityEntity.AddError(nameof(CityEntity.Name), "Must fill data.");
                    if (CityEntity.Errors.Count > 0) IsValid = false;
                }
            if (CountryEntity.TaxEntities != null)
                foreach (TaxEntity TaxEntity in CountryEntity.TaxEntities)
                {
                    if (string.IsNullOrEmpty(TaxEntity.Code))
                        TaxEntity.AddError(nameof(TaxEntity.Code), "Must fill data.");
                    if (TaxEntity.Errors.Count > 0) IsValid = false;
                }
            return IsValid;
        }

        public bool ValidateDelete(CountryEntity CountryEntity)
        {
            IsValid = true;
            Country Country = UnitOfWork.CountryRepository.Get(CountryEntity.Id);
            if (Country == null)
                CountryEntity.AddError(nameof(CountryEntity.Id), "Item doesn't existed.");
            if (CountryEntity.Errors.Count > 0) IsValid = false;
            return IsValid;
        }
    }
}
