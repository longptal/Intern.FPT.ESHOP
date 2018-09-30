using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MPermission
{
    [Route("api/Permissions")]
    public class PermissionController : CommonController
    {
        private IPermissionService PermissionService;
        public PermissionController(IPermissionService PermissionService)
        {
            this.PermissionService = PermissionService;
        }

        [Route("Count"), HttpGet]
        public long Count(PermissionSearchEntity SearchPermissionEntity)
        {
            return PermissionService.Count(EmployeeEntity, SearchPermissionEntity);
        }

        [Route(""), HttpGet]
        public List<PermissionEntity> Get(PermissionSearchEntity SearchPermissionEntity)
        {
            return PermissionService.Get(EmployeeEntity, SearchPermissionEntity);
        }
        [Route("{PermissionId}"), HttpGet]
        public PermissionEntity Get(Guid PermissionId)
        {
            return PermissionService.Get(EmployeeEntity, PermissionId);
        }
        [Route(""), HttpPost]
        public PermissionEntity Create([FromBody]PermissionEntity PermissionEntity)
        {
            return PermissionService.Create(EmployeeEntity, PermissionEntity);
        }
        [Route("{PermissionId}"), HttpPut]
        public PermissionEntity Update(Guid PermissionId, [FromBody]PermissionEntity PermissionEntity)
        {
            return PermissionService.Update(EmployeeEntity, PermissionId, PermissionEntity);
        }
        [Route("{PermissionId}"), HttpDelete]
        public bool Delete(Guid PermissionId)
        {
            return PermissionService.Delete(EmployeeEntity, PermissionId);
        }
    }
}