using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Introduction
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Route { get; set; }
        public long Cx { get; set; }
    }
}
