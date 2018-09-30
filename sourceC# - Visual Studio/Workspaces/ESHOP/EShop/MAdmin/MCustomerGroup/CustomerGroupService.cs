using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MCustomerGroup
{
    public interface ICustomerGroupService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CustomerGroupSearchEntity CustomerGroupSearchEntity);
        List<CustomerGroupEntity> Get(EmployeeEntity EmployeeEntity, CustomerGroupSearchEntity CustomerGroupSearchEntity);
        CustomerGroupEntity Get(EmployeeEntity EmployeeEntity, Guid CustomerGroupId);
        CustomerGroupEntity Create(EmployeeEntity EmployeeEntity, CustomerGroupEntity CustomerGroupEntity);
        CustomerGroupEntity Update(EmployeeEntity EmployeeEntity, Guid CustomerGroupId, CustomerGroupEntity CustomerGroupEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CustomerGroupId);
    }
    public class CustomerGroupService : CommonService, ICustomerGroupService
    {
        public CustomerGroupService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, CustomerGroupSearchEntity CustomerGroupSearchEntity)
        {
            return UnitOfWork.CustomerGroupRepository.Count(CustomerGroupSearchEntity);
        }
        public List<CustomerGroupEntity> Get(EmployeeEntity EmployeeEntity, CustomerGroupSearchEntity CustomerGroupSearchEntity)
        {
            List<CustomerGroup> CustomerGroups = UnitOfWork.CustomerGroupRepository.List(CustomerGroupSearchEntity);
            return CustomerGroups.ToList().Select(c => new CustomerGroupEntity(c)).ToList();
        }

        public CustomerGroupEntity Get(EmployeeEntity EmployeeEntity, Guid CustomerGroupId)
        {
            CustomerGroup CustomerGroup = UnitOfWork.CustomerGroupRepository.Get(CustomerGroupId);
            return new CustomerGroupEntity(CustomerGroup);
        }
        public CustomerGroupEntity Create(EmployeeEntity EmployeeEntity, CustomerGroupEntity CustomerGroupEntity)
        {
            if (CustomerGroupEntity == null)
                throw new NotFoundException();
            CustomerGroup CustomerGroup = new CustomerGroup(CustomerGroupEntity);
            UnitOfWork.CustomerGroupRepository.AddOrUpdate(CustomerGroup);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, CustomerGroup.Id);
        }
        public CustomerGroupEntity Update(EmployeeEntity EmployeeEntity, Guid CustomerGroupId, CustomerGroupEntity CustomerGroupEntity)
        {
            CustomerGroupEntity.Id = CustomerGroupId;
            CustomerGroup CustomerGroup = new CustomerGroup(CustomerGroupEntity);
            UnitOfWork.CustomerGroupRepository.AddOrUpdate(CustomerGroup);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, CustomerGroup.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CustomerGroupId)
        {
            UnitOfWork.CustomerGroupRepository.Delete(CustomerGroupId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
