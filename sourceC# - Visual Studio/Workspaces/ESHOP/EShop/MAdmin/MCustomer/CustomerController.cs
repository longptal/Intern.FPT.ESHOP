using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCustomer
{
    [Route("api/Customers")]
    public class CustomerController : CommonController
    {
        private ICustomerService CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }

        [Route("Count"), HttpGet]
        public long Count(CustomerSearchEntity SearchCustomerEntity)
        {
            return CustomerService.Count(EmployeeEntity, SearchCustomerEntity);
        }

        [Route(""), HttpGet]
        public List<CustomerEntity> Get(CustomerSearchEntity SearchCustomerEntity)
        {
            return CustomerService.Get(EmployeeEntity, SearchCustomerEntity);
        }
        [Route("{CustomerId}"), HttpGet]
        public CustomerEntity Get(Guid CustomerId)
        {
            return CustomerService.Get(EmployeeEntity, CustomerId);
        }
        [Route(""), HttpPost]
        public CustomerEntity Create([FromBody]CustomerEntity CustomerEntity)
        {
            return CustomerService.Create(EmployeeEntity, CustomerEntity);
        }
        [Route("{CustomerId}"), HttpPut]
        public CustomerEntity Update(Guid CustomerId, [FromBody]CustomerEntity CustomerEntity)
        {
            return CustomerService.Update(EmployeeEntity, CustomerId, CustomerEntity);
        }
        [Route("{CustomerId}"), HttpDelete]
        public bool Delete(Guid CustomerId)
        {
            return CustomerService.Delete(EmployeeEntity, CustomerId);
        }
    }
}