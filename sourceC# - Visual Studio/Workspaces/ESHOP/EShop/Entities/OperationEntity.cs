using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class OperationEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Path { get; set; }
        public String Method { get; set; }
        public Int32 Role { get; set; }
        public List<ModuleOperationEntity> ModuleOperationEntities { get; set; }

        public OperationEntity():base() { }

        public OperationEntity(Operation Operation, params object[] args) :base(Operation)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<ModuleOperation> ModuleOperations)
                    ModuleOperationEntities = ModuleOperations.Select(model => new ModuleOperationEntity(model, model.Module)).ToList();				
			}
        }
    }

    public class OperationSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Path { get; set; }
        public String Method { get; set; }
        public Int32? Role { get; set; }
    }
}
