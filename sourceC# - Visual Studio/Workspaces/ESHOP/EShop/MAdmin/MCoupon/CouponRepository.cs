using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MCoupon
{
    public interface ICouponRepository
    {
        int Count(CouponSearchEntity SearchCouponEntity);
        List<Coupon> List(CouponSearchEntity SearchCouponEntity);
        Coupon Get(Guid Id);
        void AddOrUpdate(Coupon Coupon);
        void Delete(Guid Id);
    }
    public class CouponRepository : CommonRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(EShopContext context) : base(context)
        {

        }

        public int Count(CouponSearchEntity SearchCouponEntity)
        {
            if (SearchCouponEntity == null) SearchCouponEntity = new CouponSearchEntity();
            IQueryable<Coupon> Coupons = context.Coupons;
            Apply(Coupons, SearchCouponEntity);
            return Coupons.Count();
        }

        public List<Coupon> List(CouponSearchEntity SearchCouponEntity)
        {
            if (SearchCouponEntity == null) SearchCouponEntity = new CouponSearchEntity();
            IQueryable<Coupon> Coupons = context.Coupons;
            Apply(Coupons, SearchCouponEntity);
            SkipAndTake(Coupons, SearchCouponEntity);
            return Coupons.ToList();
        }

        public Coupon Get(Guid Id)
        {
            Coupon Coupon = context.Coupons.Where(c => c.Id == Id).FirstOrDefault();
            if (Coupon == null)
                throw new NotFoundException();
            return Coupon;
        }

        public void AddOrUpdate(Coupon Coupon)
        {
            if (context.Entry(Coupon).State == EntityState.Detached)
                context.Set<Coupon>().Add(Coupon);
        }

        public void Delete(Guid Id)
        {
            Coupon Coupon = Get(Id);
            context.Coupons.Remove(Coupon);
        }


        private IQueryable<Coupon> Apply(IQueryable<Coupon> Coupons, CouponSearchEntity SearchCouponEntity)
        {
            if (SearchCouponEntity.Id.HasValue)
                Coupons = Coupons.Where(wh => wh.Id == SearchCouponEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchCouponEntity.Code))
                Coupons = Coupons.Where(T => T.Code.ToLower().Contains(SearchCouponEntity.Code.ToLower()));
            return Coupons;
        }
    }
}
