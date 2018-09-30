using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MWareHouse
{
    public interface IWareHouseRepository
    {
        int Count(WareHouseSearchEntity WareHouseSearchEntity);
        List<WareHouse> List(WareHouseSearchEntity WareHouseSearchEntity);
        WareHouse Get(Guid Id);
        void AddOrUpdate(WareHouse WareHouse);
        void Delete(Guid Id);
    }
    public class WareHouseRepository : CommonRepository<WareHouse>, IWareHouseRepository
    {
        public WareHouseRepository(EShopContext context) : base(context)
        {

        }

        public int Count(WareHouseSearchEntity WareHouseSearchEntity)
        {
            if (WareHouseSearchEntity == null) WareHouseSearchEntity = new WareHouseSearchEntity();
            IQueryable<WareHouse> WareHouses = context.WareHouses;
            Apply(WareHouses, WareHouseSearchEntity);
            return WareHouses.Count();
        }

        public List<WareHouse> List(WareHouseSearchEntity WareHouseSearchEntity)
        {
            if (WareHouseSearchEntity == null) WareHouseSearchEntity = new WareHouseSearchEntity();
            IQueryable<WareHouse> WareHouses = context.WareHouses
                .Include(wh => wh.Stockkeeper);
            Apply(WareHouses, WareHouseSearchEntity);
            SkipAndTake(WareHouses, WareHouseSearchEntity);
            return WareHouses.ToList();
        }

        public WareHouse Get(Guid Id)
        {
            WareHouse WareHouse = context.WareHouses.Where(c => c.Id == Id )
                .Include(wh => wh.Stockkeeper)
                .FirstOrDefault();
            if (WareHouse == null)
                throw new NotFoundException();
            return WareHouse;
        }

        public void AddOrUpdate(WareHouse WareHouse)
        {
            if (context.Entry(WareHouse).State == EntityState.Detached)
                context.Set<WareHouse>().Add(WareHouse);
        }

        public void Delete(Guid Id)
        {
            WareHouse WareHouse = Get(Id);
            context.WareHouses.Remove(WareHouse);
        }
        
        private IQueryable<WareHouse> Apply(IQueryable<WareHouse> WareHouses, WareHouseSearchEntity WareHouseSearchEntity)
        {
            if (WareHouseSearchEntity.Id.HasValue)
                WareHouses = WareHouses.Where(wh => wh.Id == WareHouseSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(WareHouseSearchEntity.Name))
                WareHouses = WareHouses.Where(wh => wh.Name.ToLower().Contains(WareHouseSearchEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(WareHouseSearchEntity.Code))
                WareHouses = WareHouses.Where(wh => wh.Code.ToLower().Contains(WareHouseSearchEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(WareHouseSearchEntity.StorageLocation))
                WareHouses = WareHouses.Where(wh => wh.StorageLocation.ToLower().Contains(WareHouseSearchEntity.StorageLocation.ToLower()));
            if (WareHouseSearchEntity.StockkeeperId.HasValue)
                WareHouses = WareHouses.Where(wh => wh.StockkeeperId == WareHouseSearchEntity.StockkeeperId);
            if (WareHouseSearchEntity.IsDefault.HasValue)
                WareHouses = WareHouses.Where(wh => wh.IsDefault == WareHouseSearchEntity.IsDefault.Value);
            return WareHouses;
        }
    }
}
