using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MCustomer
{
    public interface ICustomerRepository
    {
        int Count(CustomerSearchEntity SearchCustomerEntity);
        List<Customer> List(CustomerSearchEntity SearchCustomerEntity);
        Customer Get(Guid Id);
        void AddOrUpdate(Customer Customer);
        void Delete(Guid Id);
    }
    public class CustomerRepository : CommonRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EShopContext context) : base(context)
        {

        }

        public int Count(CustomerSearchEntity SearchCustomerEntity)
        {
            if (SearchCustomerEntity == null) SearchCustomerEntity = new CustomerSearchEntity();
            IQueryable<Customer> Customers = context.Customers;
            Apply(Customers, SearchCustomerEntity);
            return Customers.Count();
        }

        public List<Customer> List(CustomerSearchEntity SearchCustomerEntity)
        {
            if (SearchCustomerEntity == null) SearchCustomerEntity = new CustomerSearchEntity();
            IQueryable<Customer> Customers = context.Customers;
            Apply(Customers, SearchCustomerEntity);
            SkipAndTake(Customers, SearchCustomerEntity);
            return Customers.ToList();
        }

        public Customer Get(Guid Id)
        {
            Customer Customer = context.Customers.Where(c => c.Id == Id ).FirstOrDefault();
            if (Customer == null)
                throw new NotFoundException();
            return Customer;
        }

        public void AddOrUpdate(Customer Customer)
        {
            if (context.Entry(Customer).State == EntityState.Detached)
                context.Set<Customer>().Add(Customer);
        }

        public void Delete(Guid Id)
        {
            Customer Customer = Get(Id);
            context.Customers.Remove(Customer);
        }

        private IQueryable<Customer> Apply(IQueryable<Customer> Customers, CustomerSearchEntity SearchCustomerEntity)
        {
            if (SearchCustomerEntity.Id.HasValue)
                Customers = Customers.Where(wh => wh.Id == SearchCustomerEntity.Id.Value);
            if (SearchCustomerEntity.CustomerGroupId.HasValue)
                Customers = Customers.Where(wh => wh.CustomerGroupId == SearchCustomerEntity.CustomerGroupId.Value);
            if (!string.IsNullOrEmpty(SearchCustomerEntity.Username))
                Customers = Customers.Where(T => T.Username.ToLower().Contains(SearchCustomerEntity.Username.ToLower()));

            if (!string.IsNullOrEmpty(SearchCustomerEntity.Display))
                Customers = Customers.Where(T => T.Display.ToLower().Contains(SearchCustomerEntity.Display.ToLower()));

            if (!string.IsNullOrEmpty(SearchCustomerEntity.FacebookId))
                Customers = Customers.Where(T => T.FacebookId.ToLower().Contains(SearchCustomerEntity.FacebookId.ToLower()));

            if (!string.IsNullOrEmpty(SearchCustomerEntity.FacebookEmail))
                Customers = Customers.Where(T => T.FacebookEmail.ToLower().Contains(SearchCustomerEntity.FacebookEmail.ToLower()));

            if (!string.IsNullOrEmpty(SearchCustomerEntity.GoogleId))
                Customers = Customers.Where(T => T.GoogleId.ToLower().Contains(SearchCustomerEntity.GoogleId.ToLower()));

            if (!string.IsNullOrEmpty(SearchCustomerEntity.GoogleEmail))
                Customers = Customers.Where(T => T.GoogleEmail.ToLower().Contains(SearchCustomerEntity.GoogleEmail.ToLower()));
            if (!string.IsNullOrEmpty(SearchCustomerEntity.Picture))
                Customers = Customers.Where(T => T.Picture.ToLower().Contains(SearchCustomerEntity.Picture.ToLower()));

            return Customers;
        }

    }
}
