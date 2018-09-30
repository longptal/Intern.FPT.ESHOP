using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Operation
    {
        public Operation()
        {
            ModuleOperations = new HashSet<ModuleOperation>();
        }

        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public int Role { get; set; }
        public long Cx { get; set; }

        public ICollection<ModuleOperation> ModuleOperations { get; set; }
    }
}
