using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MLanguage
{
    [Route("api/Languages")]
    public class LanguageController : CommonController
    {
        private ILanguageService LanguageService;
        public LanguageController(ILanguageService LanguageService)
        {
            this.LanguageService = LanguageService;
        }

        [Route("Count"), HttpGet]
        public long Count(LanguageSearchEntity SearchLanguageEntity)
        {
            return LanguageService.Count(EmployeeEntity, SearchLanguageEntity);
        }

        [Route(""), HttpGet]
        public List<LanguageEntity> Get(LanguageSearchEntity SearchLanguageEntity)
        {
            return LanguageService.Get(EmployeeEntity, SearchLanguageEntity);
        }
        [Route("{LanguageId}"), HttpGet]
        public LanguageEntity Get(Guid LanguageId)
        {
            return LanguageService.Get(EmployeeEntity, LanguageId);
        }
        [Route(""), HttpPost]
        public LanguageEntity Create([FromBody]LanguageEntity LanguageEntity)
        {
            return LanguageService.Create(EmployeeEntity, LanguageEntity);
        }
        [Route("{LanguageId}"), HttpPut]
        public LanguageEntity Update(Guid LanguageId, [FromBody]LanguageEntity LanguageEntity)
        {
            return LanguageService.Update(EmployeeEntity, LanguageId, LanguageEntity);
        }
        [Route("{LanguageId}"), HttpDelete]
        public bool Delete(Guid LanguageId)
        {
            return LanguageService.Delete(EmployeeEntity, LanguageId);
        }
    }
}