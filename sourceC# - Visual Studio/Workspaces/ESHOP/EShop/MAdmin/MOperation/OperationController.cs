using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MOperation
{
    [Route("api/Operations")]
    public class OperationController : CommonController
    {
        private IOperationService OperationService;
        public OperationController(IOperationService OperationService)
        {
            this.OperationService = OperationService;
        }

        [Route("Count"), HttpGet]
        public long Count(OperationSearchEntity SearchOperationEntity)
        {
            return OperationService.Count(EmployeeEntity, SearchOperationEntity);
        }

        [Route(""), HttpGet]
        public List<OperationEntity> Get(OperationSearchEntity SearchOperationEntity)
        {
            return OperationService.Get(EmployeeEntity, SearchOperationEntity);
        }
        [Route("{OperationId}"), HttpGet]
        public OperationEntity Get(Guid OperationId)
        {
            return OperationService.Get(EmployeeEntity, OperationId);
        }
        [Route(""), HttpPost]
        public OperationEntity Create([FromBody]OperationEntity OperationEntity)
        {
            return OperationService.Create(EmployeeEntity, OperationEntity);
        }
        [Route("{OperationId}"), HttpPut]
        public OperationEntity Update(Guid OperationId, [FromBody]OperationEntity OperationEntity)
        {
            return OperationService.Update(EmployeeEntity, OperationId, OperationEntity);
        }
        [Route("{OperationId}"), HttpDelete]
        public bool Delete(Guid OperationId)
        {
            return OperationService.Delete(EmployeeEntity, OperationId);
        }
    }
}