using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MPack
{
    [Route("api/Packs")]
    public class PackController : CommonController
    {
        private IPackService PackService;
        public PackController(IPackService PackService)
        {
            this.PackService = PackService;
        }

        [Route("Count"), HttpGet]
        public long Count(PackSearchEntity SearchPackEntity)
        {
            return PackService.Count(EmployeeEntity, SearchPackEntity);
        }

        [Route(""), HttpGet]
        public List<PackEntity> Get(PackSearchEntity SearchPackEntity)
        {
            return PackService.Get(EmployeeEntity, SearchPackEntity);
        }
        [Route("{PackId}"), HttpGet]
        public PackEntity Get(Guid PackId)
        {
            return PackService.Get(EmployeeEntity, PackId);
        }
        [Route(""), HttpPost]
        public PackEntity Create([FromBody]PackEntity PackEntity)
        {
            return PackService.Create(EmployeeEntity, PackEntity);
        }
        [Route("{PackId}"), HttpPut]
        public PackEntity Update(Guid PackId, [FromBody]PackEntity PackEntity)
        {
            return PackService.Update(EmployeeEntity, PackId, PackEntity);
        }
        [Route("{PackId}"), HttpDelete]
        public bool Delete(Guid PackId)
        {
            return PackService.Delete(EmployeeEntity, PackId);
        }
    }
}