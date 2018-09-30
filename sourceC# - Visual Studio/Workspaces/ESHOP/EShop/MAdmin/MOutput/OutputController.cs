using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MOutput
{
    [Route("api/Outputs")]
    public class OutputController : CommonController
    {
        private IOutputService OutputService;
        public OutputController(IOutputService OutputService)
        {
            this.OutputService = OutputService;
        }

        [Route("Count"), HttpGet]
        public long Count(OutputSearchEntity SearchOutputEntity)
        {
            return OutputService.Count(EmployeeEntity, SearchOutputEntity);
        }

        [Route(""), HttpGet]
        public List<OutputEntity> Get(OutputSearchEntity SearchOutputEntity)
        {
            return OutputService.Get(EmployeeEntity, SearchOutputEntity);
        }
        [Route("{OutputId}"), HttpGet]
        public OutputEntity Get(Guid OutputId)
        {
            return OutputService.Get(EmployeeEntity, OutputId);
        }
        [Route(""), HttpPost]
        public OutputEntity Create([FromBody]OutputEntity OutputEntity)
        {
            return OutputService.Create(EmployeeEntity, OutputEntity);
        }
        [Route("{OutputId}"), HttpPut]
        public OutputEntity Update(Guid OutputId, [FromBody]OutputEntity OutputEntity)
        {
            return OutputService.Update(EmployeeEntity, OutputId, OutputEntity);
        }
        [Route("{OutputId}"), HttpDelete]
        public bool Delete(Guid OutputId)
        {
            return OutputService.Delete(EmployeeEntity, OutputId);
        }
    }
}