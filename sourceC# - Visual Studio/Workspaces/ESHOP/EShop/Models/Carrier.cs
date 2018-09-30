using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Carrier
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public long Cx { get; set; }
    }
}
