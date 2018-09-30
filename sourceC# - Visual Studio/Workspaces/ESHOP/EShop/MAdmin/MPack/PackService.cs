using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MPack
{
    public interface IPackService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, PackSearchEntity PackSearchEntity);
        List<PackEntity> Get(EmployeeEntity EmployeeEntity, PackSearchEntity PackSearchEntity);
        PackEntity Get(EmployeeEntity EmployeeEntity, Guid PackId);
        PackEntity Create(EmployeeEntity EmployeeEntity, PackEntity PackEntity);
        PackEntity Update(EmployeeEntity EmployeeEntity, Guid PackId, PackEntity PackEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid PackId);
    }
    public class PackService : CommonService, IPackService
    {
        public PackService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, PackSearchEntity PackSearchEntity)
        {
            return UnitOfWork.PackRepository.Count(PackSearchEntity);
        }
        public List<PackEntity> Get(EmployeeEntity EmployeeEntity, PackSearchEntity PackSearchEntity)
        {
            List<Pack> Packs = UnitOfWork.PackRepository.List(PackSearchEntity);
            return Packs.ToList().Select(c => new PackEntity(c)).ToList();
        }

        public PackEntity Get(EmployeeEntity EmployeeEntity, Guid PackId)
        {
            Pack Pack = UnitOfWork.PackRepository.Get(PackId);
            return new PackEntity(Pack);
        }
        public PackEntity Create(EmployeeEntity EmployeeEntity, PackEntity PackEntity)
        {
            if (PackEntity == null)
                throw new NotFoundException();
            Pack Pack = new Pack(PackEntity);
            UnitOfWork.PackRepository.AddOrUpdate(Pack);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Pack.Id);
        }
        public PackEntity Update(EmployeeEntity EmployeeEntity, Guid PackId, PackEntity PackEntity)
        {
            if (PackEntity == null)
                throw new NotFoundException();

            PackEntity.Id = PackId;
            Pack Pack = new Pack(PackEntity);
            UnitOfWork.PackRepository.AddOrUpdate(Pack);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Pack.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid PackId)
        {
            UnitOfWork.PackRepository.Delete(PackId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
