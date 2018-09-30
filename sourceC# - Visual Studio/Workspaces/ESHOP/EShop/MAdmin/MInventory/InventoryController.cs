using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;
namespace EShop.MAdmin.MInventory
{
    [Route("api/Inventories")]
    public class InventoryController : CommonController
    {
        private IInventoryService InventoryService;
        public InventoryController(IInventoryService InventoryService)
        {
            this.InventoryService = InventoryService;
        }

        [Route("Count"), HttpGet]
        public long Count(InventorySearchEntity SearchInventoryEntity)
        {
            return InventoryService.Count(EmployeeEntity, SearchInventoryEntity);
        }

        [Route(""), HttpGet]
        public List<InventoryEntity> Get(InventorySearchEntity SearchInventoryEntity)
        {
            return InventoryService.Get(EmployeeEntity, SearchInventoryEntity);
        }
        [Route("{InventoryId}"), HttpGet]
        public InventoryEntity Get(Guid InventoryId)
        {
            return InventoryService.Get(EmployeeEntity, InventoryId);
        }
        [Route(""), HttpPost]
        public InventoryEntity Create([FromBody]InventoryEntity InventoryEntity)
        {
            return InventoryService.Create(EmployeeEntity, InventoryEntity);
        }
        [Route("{InventoryId}"), HttpDelete]
        public bool Delete(Guid InventoryId)
        {
            return InventoryService.Delete(EmployeeEntity, InventoryId);
        }
    }
}