using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class CustomerGroup : Base
    {

        public CustomerGroup (CustomerGroupEntity CustomerGroupEntity) : base(CustomerGroupEntity)
        {

			if (CustomerGroupEntity.CustomerEntities != null)
            {
                this.Customers = new HashSet<Customer>();
                foreach (CustomerEntity CustomerEntity in CustomerGroupEntity.CustomerEntities)
                {
					CustomerEntity.CustomerGroupId = CustomerGroupEntity.Id;
                    this.Customers.Add(new Customer(CustomerEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is CustomerGroup CustomerGroup)
            {
                return Id.Equals(CustomerGroup.Id);
            }

            return false;
        }
    }
}
