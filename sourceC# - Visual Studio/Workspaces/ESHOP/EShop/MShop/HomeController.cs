using System;
using System.Collections.Generic;
using System.Linq;
using EShop.MAdmin;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace EShop.MShop
{
    public class HomeController : CommonController
    {
        private EShopContext EShopContext;
        public HomeController(EShopContext EShopContext)
        {
            this.EShopContext = EShopContext;
        }
        public IActionResult Index()
        {
            SecurePasswordHasher.Hash("admin");
            return View();
        }

        public IActionResult RenderCategory()
        {
            List<Category> Categories = EShopContext.Categories.ToList();
            return PartialView(Categories);
        }
    }
}