using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;

namespace EShop.MAdmin.MWareHouse
{
    public interface IWareHouseService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, WareHouseSearchEntity SearchWareHouseEntity);
        List<WareHouseEntity> Get(EmployeeEntity EmployeeEntity, WareHouseSearchEntity SearchWareHouseEntity);
        WareHouseEntity Get(EmployeeEntity EmployeeEntity, Guid WareHouseId);
        WareHouseEntity Create(EmployeeEntity EmployeeEntity, WareHouseEntity WareHouseEntity);
        WareHouseEntity Update(EmployeeEntity EmployeeEntity, Guid WareHouseId, WareHouseEntity WareHouseEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid WareHouseId);
    }
    public class WareHouseService : CommonService, IWareHouseService
    {
        public WareHouseService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, WareHouseSearchEntity WareHouseSearchEntity)
        {
            return UnitOfWork.WareHouseRepository.Count(WareHouseSearchEntity);
        }
        public List<WareHouseEntity> Get(EmployeeEntity EmployeeEntity, WareHouseSearchEntity WareHouseSearchEntity)
        {
            List<WareHouse> WareHouses = UnitOfWork.WareHouseRepository.List(WareHouseSearchEntity);
            return WareHouses.ToList().Select(c => new WareHouseEntity(c)).ToList();
        }

        public WareHouseEntity Get(EmployeeEntity EmployeeEntity, Guid WareHouseId)
        {
            WareHouse WareHouse = UnitOfWork.WareHouseRepository.Get(WareHouseId);
            return new WareHouseEntity(WareHouse, WareHouse.Stockkeeper);
        }
        public WareHouseEntity Create(EmployeeEntity EmployeeEntity, WareHouseEntity WareHouseEntity)
        {
            WareHouse WareHouse = new WareHouse(WareHouseEntity);
            UnitOfWork.WareHouseRepository.AddOrUpdate(WareHouse);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, WareHouse.Id);
        }
        public WareHouseEntity Update(EmployeeEntity EmployeeEntity, Guid WareHouseId, WareHouseEntity WareHouseEntity)
        {
            WareHouseEntity.Id = WareHouseId;
            WareHouse WareHouse = new WareHouse(WareHouseEntity);
            UnitOfWork.WareHouseRepository.AddOrUpdate(WareHouse);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, WareHouse.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid WareHouseId)
        {
            UnitOfWork.WareHouseRepository.Delete(WareHouseId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
