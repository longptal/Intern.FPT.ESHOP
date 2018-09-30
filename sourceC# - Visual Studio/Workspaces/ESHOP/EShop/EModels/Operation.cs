using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Operation : Base
    {

        public Operation (OperationEntity OperationEntity) : base(OperationEntity)
        {

			if (OperationEntity.ModuleOperationEntities != null)
            {
                this.ModuleOperations = new HashSet<ModuleOperation>();
                foreach (ModuleOperationEntity ModuleOperationEntity in OperationEntity.ModuleOperationEntities)
                {
					ModuleOperationEntity.OperationId = OperationEntity.Id;
                    this.ModuleOperations.Add(new ModuleOperation(ModuleOperationEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Operation Operation)
            {
                return Id.Equals(Operation.Id);
            }

            return false;
        }
    }
}
