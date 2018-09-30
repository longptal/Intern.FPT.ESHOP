using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;

namespace EShop.MAdmin.MShipmentDetail
{
    public interface IShipmentDetailService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, ShipmentDetailSearchEntity ShipmentDetailSearchEntity);
        List<ShipmentDetailEntity> Get(EmployeeEntity EmployeeEntity, ShipmentDetailSearchEntity ShipmentDetailSearchEntity);
        ShipmentDetailEntity Get(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId);
        ShipmentDetailEntity Create(EmployeeEntity EmployeeEntity, ShipmentDetailEntity ShipmentDetailEntity);
        ShipmentDetailEntity Update(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId, ShipmentDetailEntity ShipmentDetailEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId);
    }
    public class ShipmentDetailService : CommonService, IShipmentDetailService
    {
        public ShipmentDetailService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, ShipmentDetailSearchEntity ShipmentDetailSearchEntity)
        {
            return UnitOfWork.ShipmentDetailRepository.Count(ShipmentDetailSearchEntity);
        }
        public List<ShipmentDetailEntity> Get(EmployeeEntity EmployeeEntity, ShipmentDetailSearchEntity ShipmentDetailSearchEntity)
        {
            List<ShipmentDetail> ShipmentDetails = UnitOfWork.ShipmentDetailRepository.List(ShipmentDetailSearchEntity);
            return ShipmentDetails.ToList().Select(c => new ShipmentDetailEntity(c, c.Customer, c.City, c.Country)).ToList();
        }

        public ShipmentDetailEntity Get(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId)
        {
            ShipmentDetail ShipmentDetail = UnitOfWork.ShipmentDetailRepository.Get(ShipmentDetailId);
            return new ShipmentDetailEntity(ShipmentDetail, ShipmentDetail.Country, ShipmentDetail.City, ShipmentDetail.Customer);
        }
        public ShipmentDetailEntity Create(EmployeeEntity EmployeeEntity, ShipmentDetailEntity ShipmentDetailEntity)
        {
            if (ShipmentDetailEntity == null)
                throw new NotFoundException();
            ShipmentDetail ShipmentDetail = new ShipmentDetail(ShipmentDetailEntity);
            UnitOfWork.ShipmentDetailRepository.AddOrUpdate(ShipmentDetail);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, ShipmentDetail.Id);
        }
        public ShipmentDetailEntity Update(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId, ShipmentDetailEntity ShipmentDetailEntity)
        {
            ShipmentDetailEntity.Id = ShipmentDetailId;
            ShipmentDetail ShipmentDetail = new ShipmentDetail(ShipmentDetailEntity);
            UnitOfWork.ShipmentDetailRepository.AddOrUpdate(ShipmentDetail);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, ShipmentDetail.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid ShipmentDetailId)
        {
            UnitOfWork.ShipmentDetailRepository.Delete(ShipmentDetailId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
