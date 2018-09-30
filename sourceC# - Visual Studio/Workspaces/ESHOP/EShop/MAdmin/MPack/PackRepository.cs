using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MPack
{
    public interface IPackRepository
    {
        int Count(PackSearchEntity PackSearchEntity);
        List<Pack> List(PackSearchEntity PackSearchEntity);
        Pack Get(Guid Id);
        void AddOrUpdate(Pack Pack);
        void Delete(Guid Id);
    }
    public class PackRepository : CommonRepository<Pack>, IPackRepository
    {
        public PackRepository(EShopContext context) : base(context)
        {

        }

        public int Count(PackSearchEntity PackSearchEntity)
        {
            if (PackSearchEntity == null) PackSearchEntity = new PackSearchEntity();
            IQueryable<Pack> Packs = context.Packs;
            Apply(Packs, PackSearchEntity);
            return Packs.Count();
        }

        public List<Pack> List(PackSearchEntity PackSearchEntity)
        {
            if (PackSearchEntity == null) PackSearchEntity = new PackSearchEntity();
            IQueryable<Pack> Packs = context.Packs
                .Include(p => p.Product).ThenInclude(pro => pro.ProductValues);
            Apply(Packs, PackSearchEntity);
            SkipAndTake(Packs, PackSearchEntity);
            return Packs.ToList();
        }

        public Pack Get(Guid Id)
        {
            Pack Pack = context.Packs.Where(c => c.Id == Id )
                .Include(p => p.Product).ThenInclude(pro => pro.ProductValues)
                .FirstOrDefault();
            if (Pack == null)
                throw new NotFoundException();
            return Pack;
        }

        public void AddOrUpdate(Pack Pack)
        {
            if (context.Entry(Pack).State == EntityState.Detached)
                context.Set<Pack>().Add(Pack);
        }

        public void Delete(Guid Id)
        {
            Pack Pack = Get(Id);
            context.Packs.Remove(Pack);
        }

        private IQueryable<Pack> Apply(IQueryable<Pack> Packs, PackSearchEntity PackSearchEntity)
        {
            if (PackSearchEntity.Id.HasValue)
                Packs = Packs.Where(wh => wh.Id == PackSearchEntity.Id.Value);
            if (PackSearchEntity.ProductId.HasValue)
                Packs = Packs.Where(wh => wh.ProductId == PackSearchEntity.ProductId.Value);
            if (PackSearchEntity.UnitPrice.HasValue)
                Packs = Packs.Where(wh => wh.UnitPrice == PackSearchEntity.UnitPrice.Value);
            if (PackSearchEntity.Quantity.HasValue)
                Packs = Packs.Where(wh => wh.Quantity == PackSearchEntity.Quantity.Value);
            if (PackSearchEntity.IsDefault.HasValue)
                Packs = Packs.Where(wh => wh.IsDefault == PackSearchEntity.IsDefault.Value);
            return Packs;
        }
    }
}
