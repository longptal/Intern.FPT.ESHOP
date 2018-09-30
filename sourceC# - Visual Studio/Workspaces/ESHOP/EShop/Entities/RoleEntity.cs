using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class RoleEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public List<ModuleRoleEntity> ModuleRoleEntities { get; set; }
        public List<PermissionEntity> PermissionEntities { get; set; }

        public RoleEntity():base() { }

        public RoleEntity(Role Role, params object[] args) :base(Role)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<ModuleRole> ModuleRoles)
                    ModuleRoleEntities = ModuleRoles.Select(model => new ModuleRoleEntity(model, model.Module)).ToList();				
                if (arg is ICollection<Permission> Permissions)
                    PermissionEntities = Permissions.Select(model => new PermissionEntity(model, model.Employee)).ToList();				
			}
        }
    }

    public class RoleSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
    }
}
