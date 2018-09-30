using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ModuleRole
    {
        public Guid ModuleId { get; set; }
        public Guid RoleId { get; set; }

        public Module Module { get; set; }
        public Role Role { get; set; }
    }
}
