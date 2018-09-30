using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MRole
{
    [Route("api/Roles")]
    public class RoleController : CommonController
    {
        private IRoleService RoleService;
        public RoleController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }

        [Route("Count"), HttpGet]
        public long Count()
        {
            return RoleService.Count();
        }

        [Route(""), HttpGet]
        public List<string> Get()
        {
            return RoleService.Get();
        }

    }
}