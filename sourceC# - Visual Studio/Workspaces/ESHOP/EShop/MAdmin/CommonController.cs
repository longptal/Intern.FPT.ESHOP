using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EShop;
using EShop.MAdmin.MEmployee;
using EShop.Entities;

namespace EShop.MAdmin
{
    public class CommonController : Controller
    {
        public EmployeeEntity EmployeeEntity => (User as MyPrincipal)?.EmployeeEntity;
    }
}