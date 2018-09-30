using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;
namespace EShop.MAdmin.MInventoryCheckpoint
{
    public interface IInventoryCheckpointService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, InventoryCheckpointSearchEntity InventoryCheckpointSearchEntity);
        List<InventoryCheckpointEntity> Get(EmployeeEntity EmployeeEntity, InventoryCheckpointSearchEntity InventoryCheckpointSearchEntity);
        InventoryCheckpointEntity Get(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId);
        InventoryCheckpointEntity Create(EmployeeEntity EmployeeEntity, InventoryCheckpointEntity InventoryCheckpointEntity);
        InventoryCheckpointEntity Update(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId, InventoryCheckpointEntity InventoryCheckpointEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId);
    }
    public class InventoryCheckpointService : CommonService, IInventoryCheckpointService
    {
        public InventoryCheckpointService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, InventoryCheckpointSearchEntity InventoryCheckpointSearchEntity)
        {
            return UnitOfWork.InventoryCheckpointRepository.Count(InventoryCheckpointSearchEntity);
        }
        public List<InventoryCheckpointEntity> Get(EmployeeEntity EmployeeEntity, InventoryCheckpointSearchEntity InventoryCheckpointSearchEntity)
        {
            List<InventoryCheckpoint> InventoryCheckpoints = UnitOfWork.InventoryCheckpointRepository.List(InventoryCheckpointSearchEntity);
            return InventoryCheckpoints.ToList().Select(c => new InventoryCheckpointEntity(c)).ToList();
        }

        public InventoryCheckpointEntity Get(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId)
        {
            InventoryCheckpoint InventoryCheckpoint = UnitOfWork.InventoryCheckpointRepository.Get(InventoryCheckpointId);
            return new InventoryCheckpointEntity(InventoryCheckpoint);
        }
        public InventoryCheckpointEntity Create(EmployeeEntity EmployeeEntity, InventoryCheckpointEntity InventoryCheckpointEntity)
        {
            if (InventoryCheckpointEntity == null)
                throw new NotFoundException();
            InventoryCheckpoint InventoryCheckpoint = new InventoryCheckpoint(InventoryCheckpointEntity);
            UnitOfWork.InventoryCheckpointRepository.AddOrUpdate(InventoryCheckpoint);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, InventoryCheckpoint.Id);
        }
        public InventoryCheckpointEntity Update(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId, InventoryCheckpointEntity InventoryCheckpointEntity)
        {
            InventoryCheckpointEntity.Id = InventoryCheckpointId;
            InventoryCheckpoint InventoryCheckpoint = new InventoryCheckpoint(InventoryCheckpointEntity);
            UnitOfWork.InventoryCheckpointRepository.AddOrUpdate(InventoryCheckpoint);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, InventoryCheckpoint.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid InventoryCheckpointId)
        {
            UnitOfWork.InventoryCheckpointRepository.Delete(InventoryCheckpointId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
