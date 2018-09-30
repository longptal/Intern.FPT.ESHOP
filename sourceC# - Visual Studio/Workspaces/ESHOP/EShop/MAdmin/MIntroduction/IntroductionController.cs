using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MIntroduction
{
    [Route("api/Introductions")]
    public class IntroductionController : CommonController
    {
        private IIntroductionService IntroductionService;
        public IntroductionController(IIntroductionService IntroductionService)
        {
            this.IntroductionService = IntroductionService;
        }

        [Route("Count"), HttpGet]
        public long Count(IntroductionSearchEntity SearchIntroductionEntity)
        {
            return IntroductionService.Count(EmployeeEntity, SearchIntroductionEntity);
        }

        [Route(""), HttpGet]
        public List<IntroductionEntity> Get(IntroductionSearchEntity SearchIntroductionEntity)
        {
            return IntroductionService.Get(EmployeeEntity, SearchIntroductionEntity);
        }
        [Route("{IntroductionId}"), HttpGet]
        public IntroductionEntity Get(Guid IntroductionId)
        {
            return IntroductionService.Get(EmployeeEntity, IntroductionId);
        }
        [Route(""), HttpPost]
        public IntroductionEntity Create([FromBody]IntroductionEntity IntroductionEntity)
        {
            return IntroductionService.Create(EmployeeEntity, IntroductionEntity);
        }
        [Route("{IntroductionId}"), HttpPut]
        public IntroductionEntity Update(Guid IntroductionId, [FromBody]IntroductionEntity IntroductionEntity)
        {
            return IntroductionService.Update(EmployeeEntity, IntroductionId, IntroductionEntity);
        }
        [Route("{IntroductionId}"), HttpDelete]
        public bool Delete(Guid IntroductionId)
        {
            return IntroductionService.Delete(EmployeeEntity, IntroductionId);
        }
    }
}