using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MEmployee
{
    public interface IEmployeeRepository
    {
        int Count(EmployeeSearchEntity SearchEmployeeEntity);
        List<Employee> List(EmployeeSearchEntity SearchEmployeeEntity);
        Employee Get(Guid Id);
        void AddOrUpdate(Employee Employee);
        void Delete(Guid Id);
    }
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EShopContext context) : base(context)
        {

        }

        public int Count(EmployeeSearchEntity SearchEmployeeEntity)
        {
            if (SearchEmployeeEntity == null) SearchEmployeeEntity = new EmployeeSearchEntity();
            IQueryable<Employee> Employees = context.Employees;
            Apply(Employees, SearchEmployeeEntity);
            return Employees.Count();
        }

        public List<Employee> List(EmployeeSearchEntity SearchEmployeeEntity)
        {
            if (SearchEmployeeEntity == null) SearchEmployeeEntity = new EmployeeSearchEntity();
            IQueryable<Employee> Employees = context.Employees;
            Apply(Employees, SearchEmployeeEntity);
            SkipAndTake(Employees, SearchEmployeeEntity);
            return Employees.ToList();
        }

        public Employee Get(Guid Id)
        {
            Employee Employee = context.Employees.Where(c => c.Id == Id ).FirstOrDefault();
            if (Employee == null)
                throw new NotFoundException();
            return Employee;
        }

        public void AddOrUpdate(Employee Employee)
        {
            if (context.Entry(Employee).State == EntityState.Detached)
                context.Set<Employee>().Add(Employee);
        }

        public void Delete(Guid Id)
        {
            Employee Employee = Get(Id);
            context.Employees.Remove(Employee);
        }


        private IQueryable<Employee> Apply(IQueryable<Employee> Employees, EmployeeSearchEntity SearchEmployeeEntity)
        {
            if (SearchEmployeeEntity.Id.HasValue)
                Employees = Employees.Where(wh => wh.Id == SearchEmployeeEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.Username))
                Employees = Employees.Where(wh => wh.Username.ToLower().Contains(SearchEmployeeEntity.Username.ToLower()));
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.Password))
                Employees = Employees.Where(wh => wh.Password.ToLower().Contains(SearchEmployeeEntity.Password.ToLower()));
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.Display))
                Employees = Employees.Where(wh => wh.Display.ToLower().Contains(SearchEmployeeEntity.Display.ToLower()));
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.Phone))
                Employees = Employees.Where(wh => wh.Phone.ToLower().Contains(SearchEmployeeEntity.Phone.ToLower()));
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.IdentityCard))
                Employees = Employees.Where(wh => wh.IdentityCard.ToLower().Contains(SearchEmployeeEntity.IdentityCard.ToLower()));
            if (!string.IsNullOrEmpty(SearchEmployeeEntity.Picture))
                Employees = Employees.Where(wh => wh.Picture.ToLower().Contains(SearchEmployeeEntity.Picture.ToLower()));
            return Employees;
        }
    }
}
