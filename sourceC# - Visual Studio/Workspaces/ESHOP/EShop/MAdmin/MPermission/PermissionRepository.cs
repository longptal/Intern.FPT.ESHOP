using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MPermission
{
    public interface IPermissionRepository
    {
        int Count(PermissionSearchEntity PermissionSearchEntity);
        List<Permission> List(PermissionSearchEntity PermissionSearchEntity);
        Permission Get(Guid Id);
        void AddOrUpdate(Permission Permission);
        void Delete(Guid Id);
    }
    public class PermissionRepository : CommonRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(EShopContext context) : base(context)
        {

        }

        public int Count(PermissionSearchEntity PermissionSearchEntity)
        {
            if (PermissionSearchEntity == null) PermissionSearchEntity = new PermissionSearchEntity();
            IQueryable<Permission> Permissions = context.Permissions;
            Apply(Permissions, PermissionSearchEntity);
            return Permissions.Count();
        }

        public List<Permission> List(PermissionSearchEntity PermissionSearchEntity)
        {
            if (PermissionSearchEntity == null) PermissionSearchEntity = new PermissionSearchEntity();
            IQueryable<Permission> Permissions = context.Permissions
                .Include(p => p.Employee)
                .Include(p => p.Role);
            Apply(Permissions, PermissionSearchEntity);
            SkipAndTake(Permissions, PermissionSearchEntity);
            return Permissions.ToList();
        }

        public Permission Get(Guid Id)
        {
            Permission Permission = context.Permissions.Where(c => c.Id == Id )
                .Include(p => p.Employee)
                .Include(p => p.Role)
                .FirstOrDefault();
            if (Permission == null)
                throw new NotFoundException();
            return Permission;
        }

        public void AddOrUpdate(Permission Permission)
        {
            if (context.Entry(Permission).State == EntityState.Detached)
                context.Set<Permission>().Add(Permission);
        }

        public void Delete(Guid Id)
        {
            Permission Permission = Get(Id);
            context.Permissions.Add(Permission);
        }
        public Guid? Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? RoleId { get; set; }

        private IQueryable<Permission> Apply(IQueryable<Permission> Permissions, PermissionSearchEntity PermissionSearchEntity)
        {
            if (PermissionSearchEntity.Id.HasValue)
                Permissions = Permissions.Where(wh => wh.Id == PermissionSearchEntity.Id.Value);
            if (PermissionSearchEntity.EmployeeId.HasValue)
                Permissions = Permissions.Where(wh => wh.EmployeeId == PermissionSearchEntity.EmployeeId.Value);
            if (PermissionSearchEntity.RoleId.HasValue)
                Permissions = Permissions.Where(wh => wh.RoleId == PermissionSearchEntity.RoleId.Value);
            return Permissions;
        }
    }
}
