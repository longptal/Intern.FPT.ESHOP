using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCustomerGroup
{
    [Route("api/CustomerGroups")]
    public class CustomerGroupController : CommonController
    {
        private ICustomerGroupService CustomerGroupService;
        public CustomerGroupController(ICustomerGroupService CustomerGroupService)
        {
            this.CustomerGroupService = CustomerGroupService;
        }

        [Route("Count"), HttpGet]
        public long Count(CustomerGroupSearchEntity SearchCustomerGroupEntity)
        {
            return CustomerGroupService.Count(EmployeeEntity, SearchCustomerGroupEntity);
        }

        [Route(""), HttpGet]
        public List<CustomerGroupEntity> Get(CustomerGroupSearchEntity SearchCustomerGroupEntity)
        {
            return CustomerGroupService.Get(EmployeeEntity, SearchCustomerGroupEntity);
        }
        [Route("{CustomerGroupId}"), HttpGet]
        public CustomerGroupEntity Get(Guid CustomerGroupId)
        {
            return CustomerGroupService.Get(EmployeeEntity, CustomerGroupId);
        }
        [Route(""), HttpPost]
        public CustomerGroupEntity Create([FromBody]CustomerGroupEntity CustomerGroupEntity)
        {
            return CustomerGroupService.Create(EmployeeEntity, CustomerGroupEntity);
        }
        [Route("{CustomerGroupId}"), HttpPut]
        public CustomerGroupEntity Update(Guid CustomerGroupId, [FromBody]CustomerGroupEntity CustomerGroupEntity)
        {
            return CustomerGroupService.Update(EmployeeEntity, CustomerGroupId, CustomerGroupEntity);
        }
        [Route("{CustomerGroupId}"), HttpDelete]
        public bool Delete(Guid CustomerGroupId)
        {
            return CustomerGroupService.Delete(EmployeeEntity, CustomerGroupId);
        }
    }
}