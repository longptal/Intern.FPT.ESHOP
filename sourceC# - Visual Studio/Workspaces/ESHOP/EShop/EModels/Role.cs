using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Role : Base
    {

        public Role (RoleEntity RoleEntity) : base(RoleEntity)
        {

			if (RoleEntity.ModuleRoleEntities != null)
            {
                this.ModuleRoles = new HashSet<ModuleRole>();
                foreach (ModuleRoleEntity ModuleRoleEntity in RoleEntity.ModuleRoleEntities)
                {
					ModuleRoleEntity.RoleId = RoleEntity.Id;
                    this.ModuleRoles.Add(new ModuleRole(ModuleRoleEntity));
                }
            }

			if (RoleEntity.PermissionEntities != null)
            {
                this.Permissions = new HashSet<Permission>();
                foreach (PermissionEntity PermissionEntity in RoleEntity.PermissionEntities)
                {
					PermissionEntity.RoleId = RoleEntity.Id;
                    this.Permissions.Add(new Permission(PermissionEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Role Role)
            {
                return Id.Equals(Role.Id);
            }

            return false;
        }
    }
}
