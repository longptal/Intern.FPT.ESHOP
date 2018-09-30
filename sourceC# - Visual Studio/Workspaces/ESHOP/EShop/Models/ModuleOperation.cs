using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ModuleOperation
    {
        public Guid OperationId { get; set; }
        public Guid ModuleId { get; set; }

        public Module Module { get; set; }
        public Operation Operation { get; set; }
    }
}
