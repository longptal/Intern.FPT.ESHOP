using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Module : Base
    {

        public Module (ModuleEntity ModuleEntity) : base(ModuleEntity)
        {

			if (ModuleEntity.ModuleOperationEntities != null)
            {
                this.ModuleOperations = new HashSet<ModuleOperation>();
                foreach (ModuleOperationEntity ModuleOperationEntity in ModuleEntity.ModuleOperationEntities)
                {
					ModuleOperationEntity.ModuleId = ModuleEntity.Id;
                    this.ModuleOperations.Add(new ModuleOperation(ModuleOperationEntity));
                }
            }

			if (ModuleEntity.ModuleRoleEntities != null)
            {
                this.ModuleRoles = new HashSet<ModuleRole>();
                foreach (ModuleRoleEntity ModuleRoleEntity in ModuleEntity.ModuleRoleEntities)
                {
					ModuleRoleEntity.ModuleId = ModuleEntity.Id;
                    this.ModuleRoles.Add(new ModuleRole(ModuleRoleEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Module Module)
            {
                return Id.Equals(Module.Id);
            }

            return false;
        }
    }
}
