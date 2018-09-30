using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MCountry
{
    public interface ICountryRepository
    {
        int Count(CountrySearchEntity SearchCountryEntity);
        List<Country> List(CountrySearchEntity SearchCountryEntity);
        Country Get(Guid Id);
        bool Add(Country Country);
        bool Update(Country Country);
        bool Delete(Guid Id);
    }

    public class CountryRepository : CommonRepository<Country>, ICountryRepository
    {
        public CountryRepository(EShopContext EShopContext) : base(EShopContext)
        {

        }


        public int Count(CountrySearchEntity SearchCountryEntity)
        {
            if (SearchCountryEntity == null) SearchCountryEntity = new CountrySearchEntity();
            IQueryable<Country> Countries = context.Countries;
            Apply(Countries, SearchCountryEntity);
            return Countries.Count();
        }

        public bool Add(Country Country)
        {
            if (Country.Id == Guid.Empty) Country.Id = Guid.NewGuid();
            context.Countries.Add(Country);
            if (Country.Cities != null)
                foreach (City City in Country.Cities)
                {
                    City.Id = Guid.NewGuid();
                    context.Cities.Add(City);
                }
            if (Country.Taxes != null)
                foreach (Tax Tax in Country.Taxes)
                {
                    Tax.Id = Guid.NewGuid();
                    context.Taxes.Add(Tax);
                }
            return true;
        }
        public bool Update(Country Country)
        {
            Country Current = Get(Country.Id);
            if (Current == null) return false;
            Common<Country>.Copy(Country, Current);

            List<City> Cities = context.Cities.Where(c => c.CountryId == Country.Id).ToList();
            List<City> InsertCities, UpdateCities, DeleteCities;
            Common<City>.Split(Country.Cities, Cities, out InsertCities, out UpdateCities, out DeleteCities);
            foreach (City City in InsertCities)
            {
                City.Id = Guid.NewGuid();
                context.Cities.Add(City);
            }
            foreach (City City in UpdateCities)
            {
                City C = Cities.Where(c => c.Id == City.Id).FirstOrDefault();
                Common<City>.Copy(City, C);
            }
            foreach (City City in DeleteCities)
            {
                context.Cities.Remove(City);
            }

            List<Tax> Taxes = context.Taxes.Where(t => t.CountryId == Country.Id).ToList();
            List<Tax> InsertTaxes, UpdateTaxes, DeleteTaxes;
            Common<Tax>.Split(Country.Taxes, Taxes, out InsertTaxes, out UpdateTaxes, out DeleteTaxes);
            foreach (Tax Tax in InsertTaxes)
            {
                Tax.Id = Guid.NewGuid();
                context.Taxes.Add(Tax);
            }
            foreach (Tax Tax in UpdateTaxes)
            {
                Tax C = Taxes.Where(c => c.Id == Tax.Id).FirstOrDefault();
                Common<Tax>.Copy(Tax, C);
            }
            foreach (Tax Tax in DeleteTaxes)
            {
                context.Taxes.Remove(Tax);
            }
            return true;
        }
        public bool Delete(Guid Id)
        {
            Country Country = Get(Id);
            context.Countries.Remove(Country);
            foreach (City City in Country.Cities)
                context.Cities.Remove(City);
            foreach (Tax Tax in Country.Taxes)
                context.Taxes.Remove(Tax);
            return true;
        }

        public Country Get(Guid Id)
        {
            Country Country = context.Countries.Where(c => c.Id == Id)
                .Include(c => c.Cities)
                .Include(c => c.Taxes).ThenInclude(t => t.Category)
                .FirstOrDefault();
            return Country;
        }

        public List<Country> List(CountrySearchEntity SearchCountryEntity)
        {
            if (SearchCountryEntity == null) SearchCountryEntity = new CountrySearchEntity();
            IQueryable<Country> Countries = context.Countries
                .Include(c => c.Cities)
                .Include(c => c.Taxes).ThenInclude(t => t.Category);
            Apply(Countries, SearchCountryEntity);
            SkipAndTake(Countries, SearchCountryEntity);
            return Countries.ToList();
        }

        private IQueryable<Country> Apply(IQueryable<Country> Countries, CountrySearchEntity SearchCountryEntity)
        {
            if (SearchCountryEntity.Id.HasValue)
                Countries = Countries.Where(wh => wh.Id == SearchCountryEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchCountryEntity.Code))
                Countries = Countries.Where(T => T.Code.ToLower().Contains(SearchCountryEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(SearchCountryEntity.Name))
                Countries = Countries.Where(T => T.Name.ToLower().Contains(SearchCountryEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(SearchCountryEntity.Note))
                Countries = Countries.Where(T => T.Note.ToLower().Contains(SearchCountryEntity.Note.ToLower()));
            return Countries;
        }
    }
}
