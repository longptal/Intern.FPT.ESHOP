using System.Security.Claims;
using EShop.MAdmin.MCustomer;
using EShop.MAdmin.MEmployee;
using EShop.Entities;

namespace EShop
{
    public class MyPrincipal : ClaimsPrincipal
    {
        public MyPrincipal(EmployeeEntity EmployeeEntity = null, CustomerEntity CustomerEntity = null)
        {
            this.EmployeeEntity = EmployeeEntity;
            this.CustomerEntity = CustomerEntity;
        }

        public EmployeeEntity EmployeeEntity { get; }
        public CustomerEntity CustomerEntity { get; }

    }
}
