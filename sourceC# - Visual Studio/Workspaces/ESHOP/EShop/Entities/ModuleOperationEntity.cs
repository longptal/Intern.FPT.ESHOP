using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ModuleOperationEntity : BaseEntity
    {
        public Guid OperationId { get; set; }
        public Guid ModuleId { get; set; }
        public ModuleEntity ModuleEntity { get; set; }
        public OperationEntity OperationEntity { get; set; }

        public ModuleOperationEntity():base() { }

        public ModuleOperationEntity(ModuleOperation ModuleOperation, params object[] args) :base(ModuleOperation)
        {
		    foreach(object arg in args)
			{
                if (arg is Module Module)
                    ModuleEntity = new ModuleEntity(Module);				
                if (arg is Operation Operation)
                    OperationEntity = new OperationEntity(Operation);				
			}
        }
    }

    public class ModuleOperationSearchEntity : FilterEntity
    {
        public Guid? OperationId { get; set; }
        public Guid? ModuleId { get; set; }
    }
}
