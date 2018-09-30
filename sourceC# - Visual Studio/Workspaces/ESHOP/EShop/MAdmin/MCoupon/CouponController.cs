using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCoupon
{
    [Route("api/Coupons")]
    public class CouponController : CommonController
    {
        private ICouponService CouponService;
        public CouponController(ICouponService CouponService)
        {
            this.CouponService = CouponService;
        }

        [Route("Count"), HttpGet]
        public long Count(CouponSearchEntity SearchCouponEntity)
        {
            return CouponService.Count(EmployeeEntity, SearchCouponEntity);
        }

        [Route(""), HttpGet]
        public List<CouponEntity> Get(CouponSearchEntity SearchCouponEntity)
        {
            return CouponService.Get(EmployeeEntity, SearchCouponEntity);
        }
        [Route("{CouponId}"), HttpGet]
        public CouponEntity Get(Guid CouponId)
        {
            return CouponService.Get(EmployeeEntity, CouponId);
        }
        [Route(""), HttpPost]
        public CouponEntity Create([FromBody]CouponEntity CouponEntity)
        {
            return CouponService.Create(EmployeeEntity, CouponEntity);
        }
        [Route("{CouponId}"), HttpPut]
        public CouponEntity Update(Guid CouponId, [FromBody]CouponEntity CouponEntity)
        {
            return CouponService.Update(EmployeeEntity, CouponId, CouponEntity);
        }
        [Route("{CouponId}"), HttpDelete]
        public bool Delete(Guid CouponId)
        {
            return CouponService.Delete(EmployeeEntity, CouponId);
        }
    }
}