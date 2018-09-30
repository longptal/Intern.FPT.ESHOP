using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;
namespace EShop.MAdmin.MInventory
{
    public interface IInventoryRepository
    {
        int Count(InventorySearchEntity SearchInventoryEntity);
        List<Inventory> List(InventorySearchEntity SearchInventoryEntity);
        Inventory Get(Guid Id);
        void AddOrUpdate(Inventory Inventory);
        void Delete(Guid Id);
    }

    public class InventoryRepository : CommonRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(EShopContext EShopContext) : base(EShopContext)
        {

        }
        public void AddOrUpdate(Inventory Inventory)
        {
            if (context.Entry(Inventory).State == EntityState.Detached)
                context.Set<Inventory>().Add(Inventory);
        }

        public int Count(InventorySearchEntity SearchInventoryEntity)
        {
            if (SearchInventoryEntity == null) SearchInventoryEntity = new InventorySearchEntity();
            IQueryable<Inventory> Inventories = context.Inventories;
            Apply(Inventories, SearchInventoryEntity);
            return Inventories.Count();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Inventory Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> List(InventorySearchEntity SearchInventoryEntity)
        {
            if (SearchInventoryEntity == null) SearchInventoryEntity = new InventorySearchEntity();
            IQueryable<Inventory> Inventories = context.Inventories;
            Apply(Inventories, SearchInventoryEntity);
            SkipAndTake(Inventories, SearchInventoryEntity);
            return Inventories.ToList();
        }
       
        private IQueryable<Inventory> Apply(IQueryable<Inventory> Inventories, InventorySearchEntity SearchInventoryEntity)
        {
            if (SearchInventoryEntity.Id.HasValue)
                Inventories = Inventories.Where(wh => wh.Id == SearchInventoryEntity.Id.Value);
            if (SearchInventoryEntity.WareHouseId.HasValue)
                Inventories = Inventories.Where(wh => wh.WareHouseId == SearchInventoryEntity.WareHouseId.Value);
            if (SearchInventoryEntity.ProductId.HasValue)
                Inventories = Inventories.Where(wh => wh.ProductId == SearchInventoryEntity.ProductId.Value);
            return Inventories;
        }
    }
}
