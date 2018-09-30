using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MInventoryCheckpoint
{
    [Route("api/InventoryCheckpoints")]
    public class InventoryCheckpointController : CommonController
    {
        private IInventoryCheckpointService InventoryCheckpointService;
        public InventoryCheckpointController(IInventoryCheckpointService InventoryCheckpointService)
        {
            this.InventoryCheckpointService = InventoryCheckpointService;
        }

        [Route("Count"), HttpGet]
        public long Count(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity)
        {
            return InventoryCheckpointService.Count(EmployeeEntity, SearchInventoryCheckpointEntity);
        }

        [Route(""), HttpGet]
        public List<InventoryCheckpointEntity> Get(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity)
        {
            return InventoryCheckpointService.Get(EmployeeEntity, SearchInventoryCheckpointEntity);
        }
        [Route("{InventoryCheckpointId}"), HttpGet]
        public InventoryCheckpointEntity Get(Guid InventoryCheckpointId)
        {
            return InventoryCheckpointService.Get(EmployeeEntity, InventoryCheckpointId);
        }
        [Route(""), HttpPost]
        public InventoryCheckpointEntity Create([FromBody]InventoryCheckpointEntity InventoryCheckpointEntity)
        {
            return InventoryCheckpointService.Create(EmployeeEntity, InventoryCheckpointEntity);
        }
        [Route("{InventoryCheckpointId}"), HttpPut]
        public InventoryCheckpointEntity Update(Guid InventoryCheckpointId, [FromBody]InventoryCheckpointEntity InventoryCheckpointEntity)
        {
            return InventoryCheckpointService.Update(EmployeeEntity, InventoryCheckpointId, InventoryCheckpointEntity);
        }
        [Route("{InventoryCheckpointId}"), HttpDelete]
        public bool Delete(Guid InventoryCheckpointId)
        {
            return InventoryCheckpointService.Delete(EmployeeEntity, InventoryCheckpointId);
        }
    }
}