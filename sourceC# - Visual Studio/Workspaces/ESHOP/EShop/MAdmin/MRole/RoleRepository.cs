using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MRole
{
    public interface IRoleRepository
    {
        int Count(RoleSearchEntity RoleSearchEntity);
        List<Role> List(RoleSearchEntity RoleSearchEntity);
        Role Get(Guid Id);
        void AddOrUpdate(Role Role);
        void Delete(Guid Id);
    }
    public class RoleRepository : CommonRepository<Role>, IRoleRepository
    {
        public RoleRepository(EShopContext context) : base(context)
        {

        }

        public int Count(RoleSearchEntity RoleSearchEntity)
        {
            if (RoleSearchEntity == null) RoleSearchEntity = new RoleSearchEntity();
            IQueryable<Role> Roles = context.Roles;
            Apply(Roles, RoleSearchEntity);
            return Roles.Count();
        }

        public List<Role> List(RoleSearchEntity RoleSearchEntity)
        {
            if (RoleSearchEntity == null) RoleSearchEntity = new RoleSearchEntity();
            IQueryable<Role> Roles = context.Roles;
            Roles =  Apply(Roles, RoleSearchEntity);
            Roles = SkipAndTake(Roles, RoleSearchEntity);
            return Roles.ToList();
        }

        public Role Get(Guid Id)
        {
            Role Role = context.Roles.Where(c => c.Id == Id).FirstOrDefault();
            if (Role == null)
                throw new NotFoundException();
            return Role;
        }

        public void AddOrUpdate(Role Role)
        {
            if (context.Entry(Role).State == EntityState.Detached)
                context.Set<Role>().Add(Role);
        }

        public void Delete(Guid Id)
        {
            Role Role = Get(Id);
            context.Roles.Remove(Role);
        }


        private IQueryable<Role> Apply(IQueryable<Role> Roles, RoleSearchEntity RoleSearchEntity)
        {

            if (RoleSearchEntity.Id.HasValue)
                Roles = Roles.Where(t => t.Id == RoleSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(RoleSearchEntity.Name))
                Roles = Roles.Where(t => t.Name.ToLower().Contains(RoleSearchEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(RoleSearchEntity.Code))
                Roles = Roles.Where(t => t.Code.ToLower().Contains(RoleSearchEntity.Code.ToLower()));
            return Roles;
        }
    }
}
