using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WMS.MvcUI.Areas.Calisan.Models;
using WMS.Presantation.Models;

namespace WMS.MvcUI.Areas.Calisan.Controllers
{
    [Area("Calisan")]
    public class CalisanLoginController : Controller
    {
        private readonly ILogger<CalisanLoginController> _logger;

        public CalisanLoginController(ILogger<CalisanLoginController> logger)
        {
            _logger = logger;
        }
        private async Task<List<CalisanModel>> GetCalisanFromApi()
        {
            List<CalisanModel> calisanModels = new List<CalisanModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5002/");
                    HttpResponseMessage response = await client.GetAsync("api/Calisan");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<JObject>(apiResponse); // JSON verisini JObject olarak alın
                        var data = responseData["data"].ToString(); // "data" içindeki veriyi alın
                        calisanModels = JsonConvert.DeserializeObject<List<CalisanModel>>(data); // "data" içindeki veriyi liste olarak alın

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
            return calisanModels;
        }



        public async Task<IActionResult> CalisanLogin(string username, string password)
        {
            List<CalisanModel> calisanlar = await GetCalisanFromApi();
            var users = calisanlar.FirstOrDefault(calisan => calisan.Mail == username && calisan.Sifre == password && calisan.RolAdi == "Calisan");
            if (users != null)
            {
                TempData["UserName"] = users.Adi;
                return RedirectToAction("CalisanPage", "CalisanPage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return View(calisanlar);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}