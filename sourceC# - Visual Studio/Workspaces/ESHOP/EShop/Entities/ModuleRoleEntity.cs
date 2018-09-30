using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ModuleRoleEntity : BaseEntity
    {
        public Guid ModuleId { get; set; }
        public Guid RoleId { get; set; }
        public ModuleEntity ModuleEntity { get; set; }
        public RoleEntity RoleEntity { get; set; }

        public ModuleRoleEntity():base() { }

        public ModuleRoleEntity(ModuleRole ModuleRole, params object[] args) :base(ModuleRole)
        {
		    foreach(object arg in args)
			{
                if (arg is Module Module)
                    ModuleEntity = new ModuleEntity(Module);				
                if (arg is Role Role)
                    RoleEntity = new RoleEntity(Role);				
			}
        }
    }

    public class ModuleRoleSearchEntity : FilterEntity
    {
        public Guid? ModuleId { get; set; }
        public Guid? RoleId { get; set; }
    }
}
