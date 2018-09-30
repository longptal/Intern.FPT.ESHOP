using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MInput
{
    public interface IInputRepository
    {
        int Count(InputSearchEntity SearchInputEntity);
        List<Input> List(InputSearchEntity SearchInputEntity);
        Input Get(Guid Id);
        void AddOrUpdate(Input Input);
        void Delete(Guid Id);
    }
    public class InputRepository : CommonRepository<Input>, IInputRepository
    {
        public InputRepository(EShopContext context) : base(context)
        {

        }

        public int Count(InputSearchEntity SearchInputEntity)
        {
            if (SearchInputEntity == null) SearchInputEntity = new InputSearchEntity();
            IQueryable<Input> Inputs = context.Inputs;
            Apply(Inputs, SearchInputEntity);
            return Inputs.Count();
        }

        public List<Input> List(InputSearchEntity SearchInputEntity)
        {
            if (SearchInputEntity == null) SearchInputEntity = new InputSearchEntity();
            IQueryable<Input> Inputs = context.Inputs;
            Apply(Inputs, SearchInputEntity);
            SkipAndTake(Inputs, SearchInputEntity);
            return Inputs.ToList();
        }

        public Input Get(Guid Id)
        {
            Input Input = context.Inputs.Where(c => c.Id == Id).FirstOrDefault();
            if (Input == null)
                throw new NotFoundException();
            return Input;
        }

        public void AddOrUpdate(Input Input)
        {
            if (context.Entry(Input).State == EntityState.Detached)
                context.Set<Input>().Add(Input);
        }

        public void Delete(Guid Id)
        {
            Input Input = Get(Id);
            context.Inputs.Remove(Input);
        }

        private IQueryable<Input> Apply(IQueryable<Input> Inputs, InputSearchEntity SearchInputEntity)
        {
            if (SearchInputEntity.Id.HasValue)
                Inputs = Inputs.Where(wh => wh.Id == SearchInputEntity.Id.Value);
            if (SearchInputEntity.Quantity.HasValue)
                Inputs = Inputs.Where(wh => wh.Quantity == SearchInputEntity.Quantity.Value);
            if (SearchInputEntity.UnitPrice.HasValue)
                Inputs = Inputs.Where(wh => wh.UnitPrice == SearchInputEntity.UnitPrice.Value);
            if (SearchInputEntity.InventoryId.HasValue)
                Inputs = Inputs.Where(wh => wh.InventoryId == SearchInputEntity.InventoryId.Value);
            if (!string.IsNullOrEmpty(SearchInputEntity.Description))
                Inputs = Inputs.Where(wh => wh.Description.ToLower().Contains(SearchInputEntity.Description.ToLower()));
            return Inputs;
        }
    }
}
