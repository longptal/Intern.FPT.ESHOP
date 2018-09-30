using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MCountry
{
    public interface ICountryService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CountrySearchEntity CountrySearchEntity);
        List<CountryEntity> Get(EmployeeEntity EmployeeEntity, CountrySearchEntity CountrySearchEntity);
        CountryEntity Get(EmployeeEntity EmployeeEntity, Guid CountryId);
        CountryEntity Create(EmployeeEntity EmployeeEntity, CountryEntity CountryEntity);
        CountryEntity Update(EmployeeEntity EmployeeEntity, Guid CountryId, CountryEntity CountryEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CountryId);
    }
    public class CountryService : CommonService, ICountryService
    {
        public ICountryValidator CountryValidator;
        public CountryService(IUnitOfWork UnitOfWork, ICountryValidator CountryValidator) : base(UnitOfWork)
        {
            this.CountryValidator = CountryValidator;
        }
        public int Count(EmployeeEntity EmployeeEntity, CountrySearchEntity CountrySearchEntity)
        {
            return UnitOfWork.CountryRepository.Count(CountrySearchEntity);
        }
        public List<CountryEntity> Get(EmployeeEntity EmployeeEntity, CountrySearchEntity CountrySearchEntity)
        {
            List<Country> Countrys = UnitOfWork.CountryRepository.List(CountrySearchEntity);
            return Countrys.ToList().Select(c => new CountryEntity(c)).ToList();
        }

        public CountryEntity Get(EmployeeEntity EmployeeEntity, Guid CountryId)
        {
            Country Country = UnitOfWork.CountryRepository.Get(CountryId);
            return new CountryEntity(Country);
        }
        public CountryEntity Create(EmployeeEntity EmployeeEntity, CountryEntity CountryEntity)
        {
            if (CountryEntity == null)
                throw new NotFoundException();
            if (!CountryValidator.ValidateCreate(CountryEntity))
                throw new BadRequestException(CountryEntity);
            Country Country = new Country(CountryEntity);
            UnitOfWork.CountryRepository.Add(Country);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Country.Id);
        }
        public CountryEntity Update(EmployeeEntity EmployeeEntity, Guid CountryId, CountryEntity CountryEntity)
        {
            CountryEntity.Id = CountryId;
            if (!CountryValidator.ValidateUpdate(CountryEntity))
                throw new BadRequestException(CountryEntity);
            Country Country = new Country(CountryEntity);
            UnitOfWork.CountryRepository.Update(Country);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Country.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CountryId)
        {
            CountryEntity CountryEntity = new CountryEntity { Id = CountryId };
            if (!CountryValidator.ValidateDelete(CountryEntity))
                throw new BadRequestException(CountryEntity);
            UnitOfWork.CountryRepository.Delete(CountryId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
