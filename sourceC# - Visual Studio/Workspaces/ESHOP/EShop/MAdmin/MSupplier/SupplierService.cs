using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MSupplier
{
    public interface ISupplierService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, SupplierSearchEntity SupplierSearchEntity);
        List<SupplierEntity> Get(EmployeeEntity EmployeeEntity, SupplierSearchEntity SupplierSearchEntity);
        SupplierEntity Get(EmployeeEntity EmployeeEntity, Guid SupplierId);
        SupplierEntity Create(EmployeeEntity EmployeeEntity, SupplierEntity SupplierEntity);
        SupplierEntity Update(EmployeeEntity EmployeeEntity, Guid SupplierId, SupplierEntity SupplierEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid SupplierId);
    }
    public class SupplierService : CommonService, ISupplierService
    {
        public SupplierService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, SupplierSearchEntity SupplierSearchEntity)
        {
            return UnitOfWork.SupplierRepository.Count(SupplierSearchEntity);
        }
        public List<SupplierEntity> Get(EmployeeEntity EmployeeEntity, SupplierSearchEntity SupplierSearchEntity)
        {
            List<Supplier> Suppliers = UnitOfWork.SupplierRepository.List(SupplierSearchEntity);
            return Suppliers.ToList().Select(c => new SupplierEntity(c)).ToList();
        }

        public SupplierEntity Get(EmployeeEntity EmployeeEntity, Guid SupplierId)
        {
            Supplier Supplier = UnitOfWork.SupplierRepository.Get(SupplierId);
            return new SupplierEntity(Supplier);
        }
        public SupplierEntity Create(EmployeeEntity EmployeeEntity, SupplierEntity SupplierEntity)
        {
            if (SupplierEntity == null)
                throw new NotFoundException();
            Supplier Supplier = new Supplier(SupplierEntity);
            UnitOfWork.SupplierRepository.AddOrUpdate(Supplier);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Supplier.Id);
        }
        public SupplierEntity Update(EmployeeEntity EmployeeEntity, Guid SupplierId, SupplierEntity SupplierEntity)
        {
            if (SupplierEntity == null)
                throw new NotFoundException();
            SupplierEntity.Id = SupplierId;
            Supplier Supplier = new Supplier(SupplierEntity);
            UnitOfWork.SupplierRepository.AddOrUpdate(Supplier);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Supplier.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid SupplierId)
        {
            UnitOfWork.SupplierRepository.Delete(SupplierId);
            UnitOfWork.Complete();


            return true;
        }
    }
}
