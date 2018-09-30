using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Module
    {
        public Module()
        {
            ModuleOperations = new HashSet<ModuleOperation>();
            ModuleRoles = new HashSet<ModuleRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Cx { get; set; }

        public ICollection<ModuleOperation> ModuleOperations { get; set; }
        public ICollection<ModuleRole> ModuleRoles { get; set; }
    }
}
