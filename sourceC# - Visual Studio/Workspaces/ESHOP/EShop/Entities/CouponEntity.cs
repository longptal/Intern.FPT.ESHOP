using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CouponEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CouponEntity():base() { }

        public CouponEntity(Coupon Coupon, params object[] args) :base(Coupon)
        {
		    foreach(object arg in args)
			{
			}
        }
    }

    public class CouponSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
