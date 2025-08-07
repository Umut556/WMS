using Microsoft.AspNetCore.Mvc;

namespace WMS.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPageController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
