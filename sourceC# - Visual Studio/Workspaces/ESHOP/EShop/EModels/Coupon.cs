using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Coupon : Base
    {
        public Coupon () : base(){}

        public Coupon (CouponEntity CouponEntity) : base(CouponEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Coupon Coupon)
            {
                return Id.Equals(Coupon.Id);
            }

            return false;
        }
    }
}
