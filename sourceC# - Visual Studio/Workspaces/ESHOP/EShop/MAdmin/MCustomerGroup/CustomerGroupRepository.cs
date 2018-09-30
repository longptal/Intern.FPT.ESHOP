using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MCustomerGroup
{
    public interface ICustomerGroupRepository
    {
        int Count(CustomerGroupSearchEntity SearchCustomerGroupEntity);
        List<CustomerGroup> List(CustomerGroupSearchEntity SearchCustomerGroupEntity);
        CustomerGroup Get(Guid Id);
        void AddOrUpdate(CustomerGroup CustomerGroup);
        void Delete(Guid Id);
    }
    public class CustomerGroupRepository : CommonRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(EShopContext context) : base(context)
        {

        }

        public int Count(CustomerGroupSearchEntity SearchCustomerGroupEntity)
        {
            if (SearchCustomerGroupEntity == null) SearchCustomerGroupEntity = new CustomerGroupSearchEntity();
            IQueryable<CustomerGroup> CustomerGroups = context.CustomerGroups;
            Apply(CustomerGroups, SearchCustomerGroupEntity);
            return CustomerGroups.Count();
        }

        public List<CustomerGroup> List(CustomerGroupSearchEntity SearchCustomerGroupEntity)
        {
            if (SearchCustomerGroupEntity == null) SearchCustomerGroupEntity = new CustomerGroupSearchEntity();
            IQueryable<CustomerGroup> CustomerGroups = context.CustomerGroups;
            Apply(CustomerGroups, SearchCustomerGroupEntity);
            SkipAndTake(CustomerGroups, SearchCustomerGroupEntity);
            return CustomerGroups.ToList();
        }

        public CustomerGroup Get(Guid Id)
        {
            CustomerGroup CustomerGroup = context.CustomerGroups.Where(c => c.Id == Id ).FirstOrDefault();
            if (CustomerGroup == null)
                throw new NotFoundException();
            return CustomerGroup;
        }

        public void AddOrUpdate(CustomerGroup CustomerGroup)
        {
            if (context.Entry(CustomerGroup).State == EntityState.Detached)
                context.Set<CustomerGroup>().Add(CustomerGroup);
        }

        public void Delete(Guid Id)
        {
            CustomerGroup CustomerGroup = Get(Id);
            context.CustomerGroups.Remove(CustomerGroup);
        }

        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        private IQueryable<CustomerGroup> Apply(IQueryable<CustomerGroup> CustomerGroups, CustomerGroupSearchEntity SearchCustomerGroupEntity)
        {
            if (SearchCustomerGroupEntity.Id.HasValue)
                CustomerGroups = CustomerGroups.Where(wh => wh.Id == SearchCustomerGroupEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchCustomerGroupEntity.Code))
                CustomerGroups = CustomerGroups.Where(T => T.Code.ToLower().Contains(SearchCustomerGroupEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(SearchCustomerGroupEntity.Name))
                CustomerGroups = CustomerGroups.Where(T => T.Name.ToLower().Contains(SearchCustomerGroupEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(SearchCustomerGroupEntity.Description))
                CustomerGroups = CustomerGroups.Where(T => T.Description.ToLower().Contains(SearchCustomerGroupEntity.Description.ToLower()));
            if (SearchCustomerGroupEntity.IsActive.HasValue)
                CustomerGroups = CustomerGroups.Where(wh => wh.IsActive == SearchCustomerGroupEntity.IsActive.Value);
            return CustomerGroups;
        }
    }
}
