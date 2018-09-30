using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ModuleRole : Base
    {
        public ModuleRole () : base(){}

        public ModuleRole (ModuleRoleEntity ModuleRoleEntity) : base(ModuleRoleEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ModuleRole ModuleRole)
            {
                return ModuleId.Equals(ModuleRole.ModuleId) && RoleId.Equals(ModuleRole.RoleId);
            }

            return false;
        }
    }
}
