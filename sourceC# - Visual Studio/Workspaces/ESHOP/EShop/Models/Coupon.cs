using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Coupon
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long Cx { get; set; }
    }
}
