using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCountry
{
    [Route("api/Countries")]
    public class CountryController : CommonController
    {
        private ICountryService CountryService;
        public CountryController(ICountryService CountryService)
        {
            this.CountryService = CountryService;
        }

        [Route("Count"), HttpGet]
        public long Count(CountrySearchEntity SearchCountryEntity)
        {
            return CountryService.Count(EmployeeEntity, SearchCountryEntity);
        }

        [Route(""), HttpGet]
        public List<CountryEntity> Get(CountrySearchEntity SearchCountryEntity)
        {
            return CountryService.Get(EmployeeEntity, SearchCountryEntity);
        }
        [Route("{CountryId}"), HttpGet]
        public CountryEntity Get(Guid CountryId)
        {
            return CountryService.Get(EmployeeEntity, CountryId);
        }
        [Route(""), HttpPost]
        public CountryEntity Create([FromBody]CountryEntity CountryEntity)
        {
            return CountryService.Create(EmployeeEntity, CountryEntity);
        }
        [Route("{CountryId}"), HttpPut]
        public CountryEntity Update(Guid CountryId, [FromBody]CountryEntity CountryEntity)
        {
            return CountryService.Update(EmployeeEntity, CountryId, CountryEntity);
        }
        [Route("{CountryId}"), HttpDelete]
        public bool Delete(Guid CountryId)
        {
            return CountryService.Delete(EmployeeEntity, CountryId);
        }
    }
}