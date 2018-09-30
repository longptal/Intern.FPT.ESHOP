using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MEmployee
{
    [Route("api/Employees")]
    public class EmployeeController : CommonController
    {
        private readonly IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        [HttpGet]
        [Route("")]
        public List<EmployeeEntity> Get([FromQuery] EmployeeSearchEntity SearchEmployeeEntity)
        {
            return EmployeeService.Get(EmployeeEntity, SearchEmployeeEntity);
        }
        [HttpGet]
        [Route("Count")]
        public int Count([FromQuery] EmployeeSearchEntity SearchEmployeeEntity)
        {
            return EmployeeService.Count(EmployeeEntity, SearchEmployeeEntity);
        }
        [HttpGet]
        [Route("{EmployeeId}")]
        public EmployeeEntity Get(Guid EmployeeId)
        {
            return EmployeeService.Get(EmployeeEntity, EmployeeId);
        }
        [HttpPost]
        [Route("")]
        public EmployeeEntity Post([FromBody] EmployeeEntity EmployeeEntity)
        {
            return EmployeeService.Create(EmployeeEntity, EmployeeEntity);
        }
        [HttpPut]
        [Route("{EmployeeId}")]
        public EmployeeEntity Put(Guid EmployeeId, [FromBody] EmployeeEntity EmployeeEntity)
        {
            return EmployeeService.Update(EmployeeEntity, EmployeeId, EmployeeEntity);
        }
        [HttpDelete]
        [Route("{EmployeeId}")]
        public bool Delete(Guid EmployeeId)
        {
            return EmployeeService.Delete(EmployeeEntity, EmployeeId);
        }
    }
}