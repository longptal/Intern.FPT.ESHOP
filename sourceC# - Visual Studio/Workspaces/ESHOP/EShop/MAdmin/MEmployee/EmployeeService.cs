using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.AppStart;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;

namespace EShop.MAdmin.MEmployee
{
    public interface IEmployeeService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, EmployeeSearchEntity EmployeeSearchEntity);
        List<EmployeeEntity> Get(EmployeeEntity EmployeeEntity, EmployeeSearchEntity EmployeeSearchEntity);
        EmployeeEntity Get(EmployeeEntity EmployeeEntity, Guid EmployeeId);
        EmployeeEntity Create(EmployeeEntity EmployeeEntity, EmployeeEntity CreatedEmployeeEntity);
        EmployeeEntity Update(EmployeeEntity EmployeeEntity, Guid EmployeeId, EmployeeEntity UpdatedEmployeeEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid EmployeeId);
    }

    public class EmployeeService : CommonService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public int Count(EmployeeEntity EmployeeEntity, EmployeeSearchEntity EmployeeSearchEntity)
        {
            return UnitOfWork.EmployeeRepository.Count(EmployeeSearchEntity);
        }
        public List<EmployeeEntity> Get(EmployeeEntity EmployeeEntity, EmployeeSearchEntity EmployeeSearchEntity)
        {
            List<Employee> Employees = UnitOfWork.EmployeeRepository.List(EmployeeSearchEntity);
            return Employees.ToList().Select(P => new EmployeeEntity(P)).ToList();
        }
        public EmployeeEntity Get(EmployeeEntity EmployeeEntity, Guid EmployeeId)
        {
            Employee Employee = UnitOfWork.EmployeeRepository.Get(EmployeeId);
            return new EmployeeEntity(Employee);
        }
        public EmployeeEntity Create(EmployeeEntity EmployeeEntity, EmployeeEntity CreatedEmployeeEntity)
        {
            EShopContext EShopContext = new EShopContext();
            EmployeeEntity.Id = Guid.NewGuid();
            if (EShopContext.Employees.Any(e => e.Username.ToLower() == CreatedEmployeeEntity.Username.ToLower()))
                throw new NotFoundException();
            CreatedEmployeeEntity.Password = SecurePasswordHasher.Hash(CreatedEmployeeEntity.Password);
            Employee Employee = new Employee(CreatedEmployeeEntity);
            EShopContext.Employees.Add(Employee);
            EShopContext.SaveChanges();
            return Get(EmployeeEntity, Employee.Id);
        }
        public EmployeeEntity Update(EmployeeEntity EmployeeEntity, Guid EmployeeId, EmployeeEntity UpdatedEmployeeEntity)
        {
            EShopContext EShopContext = new EShopContext();
            if (UpdatedEmployeeEntity == null)
                throw new NotFoundException();
            //if (UpdatedEmployeeEntity.Password != Employee.Password)
            //    UpdatedEmployeeEntity.Password = SecurePasswordHasher.Hash(UpdatedEmployeeEntity.Password);
            //if (UpdatedEmployeeEntity.Username != Employee.Username)
            //{
            //    if (EShopContext.Employees.Any(e => e.Username.ToLower() == UpdatedEmployeeEntity.Username.ToLower() && e.Id != Employee.Id))
            //        throw new NotFoundException();
            //}

            UpdatedEmployeeEntity.Id = EmployeeId;
            Employee Employee = new Employee(UpdatedEmployeeEntity);
            EShopContext.SaveChanges();
            return EmployeeEntity;
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid EmployeeId)
        {
            UnitOfWork.EmployeeRepository.Delete(EmployeeId);
            UnitOfWork.Complete();
            return true;
        }
       
    }
}
