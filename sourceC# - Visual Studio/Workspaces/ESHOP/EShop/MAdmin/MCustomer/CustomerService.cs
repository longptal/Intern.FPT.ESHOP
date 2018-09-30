using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MCustomer
{
    public interface ICustomerService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CustomerSearchEntity CustomerSearchEntity);
        List<CustomerEntity> Get(EmployeeEntity EmployeeEntity, CustomerSearchEntity CustomerSearchEntity);
        CustomerEntity Get(EmployeeEntity EmployeeEntity, Guid CustomerId);
        CustomerEntity Create(EmployeeEntity EmployeeEntity, CustomerEntity CustomerEntity);
        CustomerEntity Update(EmployeeEntity EmployeeEntity, Guid CustomerId, CustomerEntity CustomerEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CustomerId);
    }
    public class CustomerService : CommonService, ICustomerService
    {
        public CustomerService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, CustomerSearchEntity CustomerSearchEntity)
        {
            return UnitOfWork.CustomerRepository.Count(CustomerSearchEntity);
        }
        public List<CustomerEntity> Get(EmployeeEntity EmployeeEntity, CustomerSearchEntity CustomerSearchEntity)
        {
            List<Customer> Customers = UnitOfWork.CustomerRepository.List(CustomerSearchEntity);
            return Customers.ToList().Select(c => new CustomerEntity(c)).ToList();
        }

        public CustomerEntity Get(EmployeeEntity EmployeeEntity, Guid CustomerId)
        {
            Customer Customer = UnitOfWork.CustomerRepository.Get(CustomerId);
            return new CustomerEntity(Customer);
        }
        public CustomerEntity Create(EmployeeEntity EmployeeEntity, CustomerEntity CustomerEntity)
        {
            if (CustomerEntity == null)
                throw new NotFoundException();
            Customer Customer = new Customer(CustomerEntity);
            UnitOfWork.CustomerRepository.AddOrUpdate(Customer);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Customer.Id);
        }
        public CustomerEntity Update(EmployeeEntity EmployeeEntity, Guid CustomerId, CustomerEntity CustomerEntity)
        {
            CustomerEntity.Id = CustomerId;
            Customer Customer = new Customer(CustomerEntity);
            UnitOfWork.CustomerRepository.AddOrUpdate(Customer);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Customer.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CustomerId)
        {
            UnitOfWork.CustomerRepository.Delete(CustomerId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
