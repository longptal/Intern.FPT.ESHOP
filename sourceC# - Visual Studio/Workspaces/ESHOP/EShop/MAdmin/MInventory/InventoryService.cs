using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;
namespace EShop.MAdmin.MInventory
{
    public interface IInventoryService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, InventorySearchEntity InventorySearchEntity);
        List<InventoryEntity> Get(EmployeeEntity EmployeeEntity, InventorySearchEntity InventorySearchEntity);
        InventoryEntity Get(EmployeeEntity EmployeeEntity, Guid InventoryId);
        InventoryEntity Create(EmployeeEntity EmployeeEntity, InventoryEntity InventoryEntity);
        InventoryEntity Update(EmployeeEntity EmployeeEntity, Guid InventoryId, InventoryEntity InventoryEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid InventoryId);
    }
    public class InventoryService : CommonService, IInventoryService
    {
        public InventoryService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, InventorySearchEntity InventorySearchEntity)
        {
            return UnitOfWork.InventoryRepository.Count(InventorySearchEntity);
        }
        public List<InventoryEntity> Get(EmployeeEntity EmployeeEntity, InventorySearchEntity InventorySearchEntity)
        {
            List<Inventory> Inventorys = UnitOfWork.InventoryRepository.List(InventorySearchEntity);
            return Inventorys.ToList().Select(c => new InventoryEntity(c)).ToList();
        }

        public InventoryEntity Get(EmployeeEntity EmployeeEntity, Guid InventoryId)
        {
            Inventory Inventory = UnitOfWork.InventoryRepository.Get(InventoryId);
            return new InventoryEntity(Inventory);
        }
        public InventoryEntity Create(EmployeeEntity EmployeeEntity, InventoryEntity InventoryEntity)
        {
            if (InventoryEntity == null)
                throw new NotFoundException();
            Inventory Inventory = new Inventory(InventoryEntity);
            UnitOfWork.InventoryRepository.AddOrUpdate(Inventory);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Inventory.Id);
        }
        public InventoryEntity Update(EmployeeEntity EmployeeEntity, Guid InventoryId, InventoryEntity InventoryEntity)
        {
            InventoryEntity.Id = InventoryId; 
            Inventory Inventory = new Inventory(InventoryEntity);
            UnitOfWork.InventoryRepository.AddOrUpdate(Inventory);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Inventory.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid InventoryId)
        {
            UnitOfWork.InventoryRepository.Delete(InventoryId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
