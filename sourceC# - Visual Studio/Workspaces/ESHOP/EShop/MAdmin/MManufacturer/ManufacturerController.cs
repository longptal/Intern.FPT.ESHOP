using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MManufacturer
{
    [Route("api/Manufacturers")]
    public class ManufacturerController : CommonController
    {
        private IManufacturerService ManufacturerService;
        public ManufacturerController(IManufacturerService ManufacturerService)
        {
            this.ManufacturerService = ManufacturerService;
        }

        [Route("Count"), HttpGet]
        public long Count(ManufacturerSearchEntity SearchManufacturerEntity)
        {
            return ManufacturerService.Count(EmployeeEntity, SearchManufacturerEntity);
        }

        [Route(""), HttpGet]
        public List<ManufacturerEntity> Get(ManufacturerSearchEntity SearchManufacturerEntity)
        {
            return ManufacturerService.Get(EmployeeEntity, SearchManufacturerEntity);
        }
        [Route("{ManufacturerId}"), HttpGet]
        public ManufacturerEntity Get(Guid ManufacturerId)
        {
            return ManufacturerService.Get(EmployeeEntity, ManufacturerId);
        }
        [Route(""), HttpPost]
        public ManufacturerEntity Create([FromBody]ManufacturerEntity ManufacturerEntity)
        {
            return ManufacturerService.Create(EmployeeEntity, ManufacturerEntity);
        }
        [Route("{ManufacturerId}"), HttpPut]
        public ManufacturerEntity Update(Guid ManufacturerId, [FromBody]ManufacturerEntity ManufacturerEntity)
        {
            return ManufacturerService.Update(EmployeeEntity, ManufacturerId, ManufacturerEntity);
        }
        [Route("{ManufacturerId}"), HttpDelete]
        public bool Delete(Guid ManufacturerId)
        {
            return ManufacturerService.Delete(EmployeeEntity, ManufacturerId);
        }
    }
}