using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class PermissionEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public RoleEntity RoleEntity { get; set; }

        public PermissionEntity():base() { }

        public PermissionEntity(Permission Permission, params object[] args) :base(Permission)
        {
		    foreach(object arg in args)
			{
                if (arg is Employee Employee)
                    EmployeeEntity = new EmployeeEntity(Employee);				
                if (arg is Role Role)
                    RoleEntity = new RoleEntity(Role);				
			}
        }
    }

    public class PermissionSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
