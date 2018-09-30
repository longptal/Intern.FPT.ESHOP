using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MInventoryCheckpoint
{
    public interface IInventoryCheckpointRepository
    {
        int Count(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity);
        List<InventoryCheckpoint> List(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity);
        InventoryCheckpoint Get(Guid Id);
        void AddOrUpdate(InventoryCheckpoint InventoryCheckpoint);
        void Delete(Guid Id);
    }
    public class InventoryCheckpointRepository : CommonRepository<InventoryCheckpoint>, IInventoryCheckpointRepository
    {
        public InventoryCheckpointRepository(EShopContext context) : base(context)
        {

        }

        public int Count(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity)
        {
            if (SearchInventoryCheckpointEntity == null) SearchInventoryCheckpointEntity = new InventoryCheckpointSearchEntity();
            IQueryable<InventoryCheckpoint> InventoryCheckpoints = context.InventoryCheckpoints;
            Apply(InventoryCheckpoints, SearchInventoryCheckpointEntity);
            return InventoryCheckpoints.Count();
        }

        public List<InventoryCheckpoint> List(InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity)
        {
            if (SearchInventoryCheckpointEntity == null) SearchInventoryCheckpointEntity = new InventoryCheckpointSearchEntity();
            IQueryable<InventoryCheckpoint> InventoryCheckpoints = context.InventoryCheckpoints;
            Apply(InventoryCheckpoints, SearchInventoryCheckpointEntity);
            SkipAndTake(InventoryCheckpoints, SearchInventoryCheckpointEntity);
            return InventoryCheckpoints.ToList();
        }

        public InventoryCheckpoint Get(Guid Id)
        {
            InventoryCheckpoint InventoryCheckpoint = context.InventoryCheckpoints.Where(c => c.Id == Id).FirstOrDefault();
            if (InventoryCheckpoint == null)
                throw new NotFoundException();
            return InventoryCheckpoint;
        }

        public void AddOrUpdate(InventoryCheckpoint InventoryCheckpoint)
        {
            if (context.Entry(InventoryCheckpoint).State == EntityState.Detached)
                context.Set<InventoryCheckpoint>().Add(InventoryCheckpoint);
        }

        public void Delete(Guid Id)
        {
            InventoryCheckpoint InventoryCheckpoint = Get(Id);
            context.InventoryCheckpoints.Remove(InventoryCheckpoint);
        }

        private IQueryable<InventoryCheckpoint> Apply(IQueryable<InventoryCheckpoint> InventoryCheckpoints, InventoryCheckpointSearchEntity SearchInventoryCheckpointEntity)
        {
            if (SearchInventoryCheckpointEntity.Id.HasValue)
                InventoryCheckpoints = InventoryCheckpoints.Where(wh => wh.Id == SearchInventoryCheckpointEntity.Id.Value);
            if (SearchInventoryCheckpointEntity.InventoryId.HasValue)
                InventoryCheckpoints = InventoryCheckpoints.Where(wh => wh.InventoryId == SearchInventoryCheckpointEntity.InventoryId.Value);
            if (SearchInventoryCheckpointEntity.Current.HasValue)
                InventoryCheckpoints = InventoryCheckpoints.Where(wh => wh.Current == SearchInventoryCheckpointEntity.Current.Value);

            return InventoryCheckpoints;
        }
    }
}
