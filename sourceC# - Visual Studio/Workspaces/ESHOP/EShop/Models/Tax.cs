using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Tax
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public Guid CountryId { get; set; }
        public Guid CategoryId { get; set; }
        public long Cx { get; set; }

        public Category Category { get; set; }
        public Country Country { get; set; }
    }
}
