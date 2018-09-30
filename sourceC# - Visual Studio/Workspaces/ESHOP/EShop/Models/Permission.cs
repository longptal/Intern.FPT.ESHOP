using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Permission
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid EmployeeId { get; set; }
        public long Cx { get; set; }

        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
