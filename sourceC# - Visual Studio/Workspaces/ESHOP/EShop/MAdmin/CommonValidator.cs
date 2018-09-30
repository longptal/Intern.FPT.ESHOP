using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.MAdmin
{
    public class CommonValidator
    {
        protected IUnitOfWork UnitOfWork;
        protected bool IsValid;
        public CommonValidator(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
    }
}
