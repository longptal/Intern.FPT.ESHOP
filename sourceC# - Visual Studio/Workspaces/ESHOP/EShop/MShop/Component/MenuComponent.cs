using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.MShop.Component
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(int employeeId)
        {
            List<string> model = new List<string>()
            {
                "Trang chủ",
                "Giới thiệu"
            };
            return View(model);
        }
    }
}
