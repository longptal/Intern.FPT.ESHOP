using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ModuleOperation : Base
    {
        public ModuleOperation () : base(){}

        public ModuleOperation (ModuleOperationEntity ModuleOperationEntity) : base(ModuleOperationEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is ModuleOperation ModuleOperation)
            {
                return OperationId.Equals(ModuleOperation.OperationId) && ModuleId.Equals(ModuleOperation.ModuleId);
            }

            return false;
        }
    }
}
