using Microsoft.AspNetCore.Mvc;

namespace WMS.MvcUI.Areas.Magaza.Controllers
{
	[Area("Magaza")]
	public class MagazaPageController : Controller
	{
		public IActionResult MagazaPage()
		{
			return View();
		}
	}
}
