using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using WMS.MvcUI.Areas.Admin.Controllers;
using WMS.Presantation.Models;
using WMS.MvcUI.Areas.Magaza.Models;

namespace WMS.MvcUI.Areas.Magaza.Controllers
{
    [Area("Magaza")]
    public class MagazaLoginController : Controller
    {
        private readonly ILogger<MagazaLoginController> _logger;

        public MagazaLoginController(ILogger<MagazaLoginController> logger)
        {
            _logger= logger;
        }

		private async Task<List<MagazaModel>> GetMagazaFromApi()
		{
			List<MagazaModel> magazaModels = new List<MagazaModel>();
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:5002/");
					HttpResponseMessage response = await client.GetAsync("api/Magaza");
					if (response.IsSuccessStatusCode)
					{
						var apiResponse = await response.Content.ReadAsStringAsync();
						var responseData = JsonConvert.DeserializeObject<JObject>(apiResponse); // JSON verisini JObject olarak alın
						var data = responseData["data"].ToString(); // "data" içindeki veriyi alın
						magazaModels = JsonConvert.DeserializeObject<List<MagazaModel>>(data); // "data" içindeki veriyi liste olarak alın

					}
					else
					{
						ModelState.AddModelError(string.Empty, "API HATASI");
					}
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
			}
			return magazaModels;
		}


		public async Task<IActionResult> MagazaLogin(string username, string password)
		{
			List<MagazaModel> magazalar = await GetMagazaFromApi();
			var users = magazalar.FirstOrDefault(magaza => magaza.Mail == username && magaza.Sifre == password);
			if (users != null)
			{
				TempData["UserName"] = users.MagazaAdi;
				return RedirectToAction("MagazaPage", "MagazaPage");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Mağaza adı veya şifre hatalı.");
				return View(magazalar);
			}
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}
