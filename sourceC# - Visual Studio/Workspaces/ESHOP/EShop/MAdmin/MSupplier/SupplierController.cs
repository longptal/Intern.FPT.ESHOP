using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MSupplier
{
    [Route("api/Suppliers")]
    public class SupplierController : CommonController
    {
        private ISupplierService SupplierService;
        public SupplierController(ISupplierService SupplierService)
        {
            this.SupplierService = SupplierService;
        }

        [Route("Count"), HttpGet]
        public long Count(SupplierSearchEntity SearchSupplierEntity)
        {
            return SupplierService.Count(EmployeeEntity, SearchSupplierEntity);
        }

        [Route(""), HttpGet]
        public List<SupplierEntity> Get(SupplierSearchEntity SearchSupplierEntity)
        {
            return SupplierService.Get(EmployeeEntity, SearchSupplierEntity);
        }
        [Route("{SupplierId}"), HttpGet]
        public SupplierEntity Get(Guid SupplierId)
        {
            return SupplierService.Get(EmployeeEntity, SupplierId);
        }
        [Route(""), HttpPost]
        public SupplierEntity Create([FromBody]SupplierEntity SupplierEntity)
        {
            return SupplierService.Create(EmployeeEntity, SupplierEntity);
        }
        [Route("{SupplierId}"), HttpPut]
        public SupplierEntity Update(Guid SupplierId, [FromBody]SupplierEntity SupplierEntity)
        {
            return SupplierService.Update(EmployeeEntity, SupplierId, SupplierEntity);
        }
        [Route("{SupplierId}"), HttpDelete]
        public bool Delete(Guid SupplierId)
        {
            return SupplierService.Delete(EmployeeEntity, SupplierId);
        }
    }
}