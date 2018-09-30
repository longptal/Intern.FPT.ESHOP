using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MWareHouse
{
    [Route("api/WareHouses")]
    public class WareHouseController : CommonController
    {
        private IWareHouseService WareHouseService;
        public WareHouseController(IWareHouseService WareHouseService)
        {
            this.WareHouseService = WareHouseService;
        }

        [Route("Count"), HttpGet]
        public long Count(WareHouseSearchEntity SearchWareHouseEntity)
        {
            return WareHouseService.Count(EmployeeEntity, SearchWareHouseEntity);
        }

        [Route(""), HttpGet]
        public List<WareHouseEntity> Get(WareHouseSearchEntity SearchWareHouseEntity)
        {
            return WareHouseService.Get(EmployeeEntity, SearchWareHouseEntity);
        }
        [Route("{WareHouseId}"), HttpGet]
        public WareHouseEntity Get(Guid WareHouseId)
        {
            return WareHouseService.Get(EmployeeEntity, WareHouseId);
        }
        [Route(""), HttpPost]
        public WareHouseEntity Create([FromBody]WareHouseEntity WareHouseEntity)
        {
            return WareHouseService.Create(EmployeeEntity, WareHouseEntity);
        }
        [Route("{WareHouseId}"), HttpPut]
        public WareHouseEntity Update(Guid WareHouseId, [FromBody]WareHouseEntity WareHouseEntity)
        {
            return WareHouseService.Update(EmployeeEntity, WareHouseId, WareHouseEntity);
        }
        [Route("{WareHouseId}"), HttpDelete]
        public bool Delete(Guid WareHouseId)
        {
            return WareHouseService.Delete(EmployeeEntity, WareHouseId);
        }
    }
}