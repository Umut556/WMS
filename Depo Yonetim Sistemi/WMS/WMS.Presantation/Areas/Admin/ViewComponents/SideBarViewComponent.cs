using WMS.MvcUI.Areas.Admin.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WMS.MvcUI.Areas.Admin.Models;

namespace WMS.MvcUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var adminUser = HttpContext.Session.GetObject<AdminModelItem>("ActiveAdminUser");

            return View(adminUser);
        }
    }
}
