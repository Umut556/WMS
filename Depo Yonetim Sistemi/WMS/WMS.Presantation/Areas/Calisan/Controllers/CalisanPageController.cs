using Microsoft.AspNetCore.Mvc;

namespace WMS.MvcUI.Areas.Calisan.Controllers
{
    [Area("Calisan")]
    public class CalisanPageController : Controller
    {
        public IActionResult CalisanPage()
        {
            return View();
        }
    }
}
