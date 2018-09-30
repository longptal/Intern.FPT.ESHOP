using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MShipmentDetail
{
    [Route("api/ShipmentDetails")]
    public class ShipmentDetailController : CommonController
    {
        private IShipmentDetailService ShipmentDetailService;
        public ShipmentDetailController(IShipmentDetailService ShipmentDetailService)
        {
            this.ShipmentDetailService = ShipmentDetailService;
        }

        [Route("Count"), HttpGet]
        public long Count(ShipmentDetailSearchEntity SearchShipmentDetailEntity)
        {
            return ShipmentDetailService.Count(EmployeeEntity, SearchShipmentDetailEntity);
        }

        [Route(""), HttpGet]
        public List<ShipmentDetailEntity> Get(ShipmentDetailSearchEntity SearchShipmentDetailEntity)
        {
            return ShipmentDetailService.Get(EmployeeEntity, SearchShipmentDetailEntity);
        }
        [Route("{ShipmentDetailId}"), HttpGet]
        public ShipmentDetailEntity Get(Guid ShipmentDetailId)
        {
            return ShipmentDetailService.Get(EmployeeEntity, ShipmentDetailId);
        }
        [Route(""), HttpPost]
        public ShipmentDetailEntity Create([FromBody]ShipmentDetailEntity ShipmentDetailEntity)
        {
            return ShipmentDetailService.Create(EmployeeEntity, ShipmentDetailEntity);
        }
        [Route("{ShipmentDetailId}"), HttpPut]
        public ShipmentDetailEntity Update(Guid ShipmentDetailId, [FromBody]ShipmentDetailEntity ShipmentDetailEntity)
        {
            return ShipmentDetailService.Update(EmployeeEntity, ShipmentDetailId, ShipmentDetailEntity);
        }
        [Route("{ShipmentDetailId}"), HttpDelete]
        public bool Delete(Guid ShipmentDetailId)
        {
            return ShipmentDetailService.Delete(EmployeeEntity, ShipmentDetailId);
        }
    }
}