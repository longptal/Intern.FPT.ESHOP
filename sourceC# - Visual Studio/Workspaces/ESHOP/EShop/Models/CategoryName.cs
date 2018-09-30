using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class CategoryName
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public long Cx { get; set; }

        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
