using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MOutput
{
    public interface IOutputRepository
    {
        int Count(OutputSearchEntity OutputSearchEntity);
        List<Output> List(OutputSearchEntity OutputSearchEntity);
        Output Get(Guid Id);
        void AddOrUpdate(Output Output);
        void Delete(Guid Id);
    }
    public class OutputRepository : CommonRepository<Output>, IOutputRepository
    {
        public OutputRepository(EShopContext context) : base(context)
        {

        }

        public int Count(OutputSearchEntity OutputSearchEntity)
        {
            if (OutputSearchEntity == null) OutputSearchEntity = new OutputSearchEntity();
            IQueryable<Output> Outputs = context.Outputs;
            Apply(Outputs, OutputSearchEntity);
            return Outputs.Count();
        }

        public List<Output> List(OutputSearchEntity OutputSearchEntity)
        {
            if (OutputSearchEntity == null) OutputSearchEntity = new OutputSearchEntity();
            IQueryable<Output> Outputs = context.Outputs;
            Apply(Outputs, OutputSearchEntity);
            SkipAndTake(Outputs, OutputSearchEntity);
            return Outputs.ToList();
        }

        public Output Get(Guid Id)
        {
            Output Output = context.Outputs.Where(c => c.Id == Id).FirstOrDefault();
            if (Output == null)
                throw new NotFoundException();
            return Output;
        }

        public void AddOrUpdate(Output Output)
        {
            if (context.Entry(Output).State == EntityState.Detached)
                context.Set<Output>().Add(Output);
        }

        public void Delete(Guid Id)
        {
            Output Output = Get(Id);
            context.Outputs.Remove(Output);
        }

        private IQueryable<Output> Apply(IQueryable<Output> Outputs, OutputSearchEntity OutputSearchEntity)
        {
            if (OutputSearchEntity.Id.HasValue)
                Outputs = Outputs.Where(wh => wh.Id == OutputSearchEntity.Id.Value);
            if (OutputSearchEntity.Quantity.HasValue)
                Outputs = Outputs.Where(wh => wh.Quantity == OutputSearchEntity.Quantity.Value);
            if (OutputSearchEntity.UnitPrice.HasValue)
                Outputs = Outputs.Where(wh => wh.UnitPrice == OutputSearchEntity.UnitPrice.Value);
            if (OutputSearchEntity.InventoryId.HasValue)
                Outputs = Outputs.Where(wh => wh.InventoryId == OutputSearchEntity.InventoryId.Value);
            return Outputs;
        }
    }
}
