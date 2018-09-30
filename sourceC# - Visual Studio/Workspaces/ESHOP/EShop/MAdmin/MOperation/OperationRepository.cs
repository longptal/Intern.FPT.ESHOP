using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;
namespace EShop.MAdmin.MOperation
{
    public interface IOperationRepository
    {
        int Count(OperationSearchEntity OperationSearchEntity);
        List<Operation> List(OperationSearchEntity OperationSearchEntity);
        Operation Get(Guid Id);
        void AddOrUpdate(Operation Operation);
        void Delete(Guid Id);
    }
    public class OperationRepository : CommonRepository<Operation>, IOperationRepository
    {
        public OperationRepository(EShopContext context) : base(context)
        {

        }

        public int Count(OperationSearchEntity OperationSearchEntity)
        {
            if (OperationSearchEntity == null) OperationSearchEntity = new OperationSearchEntity();
            IQueryable<Operation> Operations = context.Operations;
            Apply(Operations, OperationSearchEntity);
            return Operations.Count();
        }

        public List<Operation> List(OperationSearchEntity OperationSearchEntity)
        {
            if (OperationSearchEntity == null) OperationSearchEntity = new OperationSearchEntity();
            IQueryable<Operation> Operations = context.Operations;
            Apply(Operations, OperationSearchEntity);
            SkipAndTake(Operations, OperationSearchEntity);
            return Operations.ToList();
        }

        public Operation Get(Guid Id)
        {
            Operation Operation = context.Operations.Where(c => c.Id == Id).FirstOrDefault();
            if (Operation == null)
                throw new NotFoundException();
            return Operation;
        }

        public void AddOrUpdate(Operation Operation)
        {
            if (context.Entry(Operation).State == EntityState.Detached)
                context.Set<Operation>().Add(Operation);
        }

        public void Delete(Guid Id)
        {
            Operation Operation = Get(Id);
            context.Operations.Remove(Operation);
        }
        
        private IQueryable<Operation> Apply(IQueryable<Operation> Operations, OperationSearchEntity OperationSearchEntity)
        {
            if (OperationSearchEntity.Id.HasValue)
                Operations = Operations.Where(wh => wh.Id == OperationSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(OperationSearchEntity.Path))
                Operations = Operations.Where(wh => wh.Path.ToLower().Contains(OperationSearchEntity.Path.ToLower()));
            if (!string.IsNullOrEmpty(OperationSearchEntity.Method))
                Operations = Operations.Where(wh => wh.Method.ToLower().Contains(OperationSearchEntity.Method.ToLower()));
            if (OperationSearchEntity.Role.HasValue)
                Operations = Operations.Where(wh => wh.Role == OperationSearchEntity.Role.Value);
            return Operations;
        }
    }
}
