using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CustomerGroupEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean IsActive { get; set; }
        public List<CustomerEntity> CustomerEntities { get; set; }

        public CustomerGroupEntity():base() { }

        public CustomerGroupEntity(CustomerGroup CustomerGroup, params object[] args) :base(CustomerGroup)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<Customer> Customers)
                    CustomerEntities = Customers.Select(model => new CustomerEntity(model)).ToList();				
			}
        }
    }

    public class CustomerGroupSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
