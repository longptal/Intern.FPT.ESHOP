using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MManufacturer
{
    public interface IManufacturerService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, ManufacturerSearchEntity ManufacturerSearchEntity);
        List<ManufacturerEntity> Get(EmployeeEntity EmployeeEntity, ManufacturerSearchEntity ManufacturerSearchEntity);
        ManufacturerEntity Get(EmployeeEntity EmployeeEntity, Guid ManufacturerId);
        ManufacturerEntity Create(EmployeeEntity EmployeeEntity, ManufacturerEntity ManufacturerEntity);
        ManufacturerEntity Update(EmployeeEntity EmployeeEntity, Guid ManufacturerId, ManufacturerEntity ManufacturerEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid ManufacturerId);
    }
    public class ManufacturerService : CommonService, IManufacturerService
    {
        public ManufacturerService(IUnitOfWork UnitOfWork) : base (UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, ManufacturerSearchEntity ManufacturerSearchEntity)
        {
            return UnitOfWork.ManufacturerRepository.Count(ManufacturerSearchEntity);
        }
        public List<ManufacturerEntity> Get(EmployeeEntity EmployeeEntity, ManufacturerSearchEntity ManufacturerSearchEntity)
        {
            List<Manufacturer> Manufacturers = UnitOfWork.ManufacturerRepository.List(ManufacturerSearchEntity);
            return Manufacturers.ToList().Select(c => new ManufacturerEntity(c)).ToList();
        }

        public ManufacturerEntity Get(EmployeeEntity EmployeeEntity, Guid ManufacturerId)
        {
            Manufacturer Manufacturer = UnitOfWork.ManufacturerRepository.Get(ManufacturerId);
            return new ManufacturerEntity(Manufacturer);
        }
        public ManufacturerEntity Create(EmployeeEntity EmployeeEntity, ManufacturerEntity ManufacturerEntity)
        {
            if (ManufacturerEntity == null)
                throw new NotFoundException();
            Manufacturer Manufacturer = new Manufacturer(ManufacturerEntity);
            UnitOfWork.ManufacturerRepository.AddOrUpdate(Manufacturer);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Manufacturer.Id);
        }
        public ManufacturerEntity Update(EmployeeEntity EmployeeEntity, Guid ManufacturerId, ManufacturerEntity ManufacturerEntity)
        {
            if (ManufacturerEntity == null)
                throw new NotFoundException();
            ManufacturerEntity.Id = ManufacturerId;
            Manufacturer Manufacturer = new Manufacturer(ManufacturerEntity);
            UnitOfWork.ManufacturerRepository.AddOrUpdate(Manufacturer);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Manufacturer.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid ManufacturerId)
        {
            UnitOfWork.ManufacturerRepository.Delete(ManufacturerId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
