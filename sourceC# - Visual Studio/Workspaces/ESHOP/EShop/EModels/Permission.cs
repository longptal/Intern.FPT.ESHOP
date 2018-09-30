using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Permission : Base
    {
        public Permission () : base(){}

        public Permission (PermissionEntity PermissionEntity) : base(PermissionEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Permission Permission)
            {
                return Id.Equals(Permission.Id);
            }

            return false;
        }
    }
}
