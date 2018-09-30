using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCarrier
{
    [Route("api/Carriers")]
    public class CarrierController : CommonController
    {
        private ICarrierService CarrierService;
        public CarrierController(ICarrierService CarrierService)
        {
            this.CarrierService = CarrierService;
        }

        [Route("Count"), HttpGet]
        public long Count(CarrierSearchEntity CarrierSearchEntity)
        {
            return CarrierService.Count(EmployeeEntity, CarrierSearchEntity);
        }

        [Route(""), HttpGet]
        public List<CarrierEntity> Get(CarrierSearchEntity CarrierSearchEntity)
        {
            return CarrierService.Get(EmployeeEntity, CarrierSearchEntity);
        }
        [Route("{CarrierId}"), HttpGet]
        public CarrierEntity Get(Guid CarrierId)
        {
            return CarrierService.Get(EmployeeEntity, CarrierId);
        }
        [Route(""), HttpPost]
        public CarrierEntity Create([FromBody]CarrierEntity CarrierEntity)
        {
            return CarrierService.Create(EmployeeEntity, CarrierEntity);
        }
        [Route("{CarrierId}"), HttpPut]
        public CarrierEntity Update(Guid CarrierId, [FromBody]CarrierEntity CarrierEntity)
        {
            return CarrierService.Update(EmployeeEntity, CarrierId, CarrierEntity);
        }
        [Route("{CarrierId}"), HttpDelete]
        public bool Delete(Guid CarrierId)
        {
            return CarrierService.Delete(EmployeeEntity, CarrierId);
        }
    }
}