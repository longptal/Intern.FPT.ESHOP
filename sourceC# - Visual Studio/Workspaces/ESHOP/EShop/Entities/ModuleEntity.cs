using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ModuleEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<ModuleOperationEntity> ModuleOperationEntities { get; set; }
        public List<ModuleRoleEntity> ModuleRoleEntities { get; set; }

        public ModuleEntity():base() { }

        public ModuleEntity(Module Module, params object[] args) :base(Module)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<ModuleOperation> ModuleOperations)
                    ModuleOperationEntities = ModuleOperations.Select(model => new ModuleOperationEntity(model, model.Operation)).ToList();				
                if (arg is ICollection<ModuleRole> ModuleRoles)
                    ModuleRoleEntities = ModuleRoles.Select(model => new ModuleRoleEntity(model, model.Role)).ToList();				
			}
        }
    }

    public class ModuleSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
    }
}
