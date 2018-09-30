using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MCoupon
{
    public interface ICouponService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CouponSearchEntity CouponSearchEntity);
        List<CouponEntity> Get(EmployeeEntity EmployeeEntity, CouponSearchEntity CouponSearchEntity);
        CouponEntity Get(EmployeeEntity EmployeeEntity, Guid CouponId);
        CouponEntity Create(EmployeeEntity EmployeeEntity, CouponEntity CouponEntity);
        CouponEntity Update(EmployeeEntity EmployeeEntity, Guid CouponId, CouponEntity CouponEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CouponId);
    }
    public class CouponService : CommonService, ICouponService
    {
        public CouponService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, CouponSearchEntity CouponSearchEntity)
        {
            return UnitOfWork.CouponRepository.Count(CouponSearchEntity);
        }
        public List<CouponEntity> Get(EmployeeEntity EmployeeEntity, CouponSearchEntity CouponSearchEntity)
        {
            List<Coupon> Coupons = UnitOfWork.CouponRepository.List(CouponSearchEntity);
            return Coupons.ToList().Select(c => new CouponEntity(c)).ToList();
        }

        public CouponEntity Get(EmployeeEntity EmployeeEntity, Guid CouponId)
        {
            Coupon Coupon = UnitOfWork.CouponRepository.Get(CouponId);
            return new CouponEntity(Coupon);
        }
        public CouponEntity Create(EmployeeEntity EmployeeEntity, CouponEntity CouponEntity)
        {
            if (CouponEntity == null)
                throw new NotFoundException();
            Coupon Coupon = new Coupon(CouponEntity);
            UnitOfWork.CouponRepository.AddOrUpdate(Coupon);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Coupon.Id);
        }
        public CouponEntity Update(EmployeeEntity EmployeeEntity, Guid CouponId, CouponEntity CouponEntity)
        {
            CouponEntity.Id = CouponId;
            Coupon Coupon = new Coupon(CouponEntity);
            UnitOfWork.CouponRepository.AddOrUpdate(Coupon);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Coupon.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CouponId)
        {
            UnitOfWork.CouponRepository.Delete(CouponId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
