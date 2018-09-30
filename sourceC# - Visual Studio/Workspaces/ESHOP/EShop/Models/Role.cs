using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Role
    {
        public Role()
        {
            ModuleRoles = new HashSet<ModuleRole>();
            Permissions = new HashSet<Permission>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Cx { get; set; }

        public ICollection<ModuleRole> ModuleRoles { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
