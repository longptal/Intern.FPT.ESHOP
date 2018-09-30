using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MRole
{
    public interface IRoleService : ITransientService
    {
        int Count();
        List<string> Get();
    }
    public class RoleService : CommonService, IRoleService
    {
        public RoleService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count()
        {
            return 0;
        }
        public List<string> Get()
        {
            return null;
        }

      
    }
}
