using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WMS.MvcUI.Areas.Admin.Models;
using WMS.MvcUI.Controllers;
using WMS.Presantation.Models;


namespace WMS.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLoginController : Controller
    {
        private readonly ILogger<AdminLoginController> _logger;

        public AdminLoginController(ILogger<AdminLoginController> logger)
        {
            _logger = logger;
        }

        private async Task<List<AdminModel>> GetAdminFromApi()
        {
            List<AdminModel> adminModels = new List<AdminModel>();
            try
            {
                using(var client=new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5002/");
                    HttpResponseMessage response = await client.GetAsync("api/Calisan");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<JObject>(apiResponse); // JSON verisini JObject olarak alın
                        var data = responseData["data"].ToString(); // "data" içindeki veriyi alın
                        adminModels = JsonConvert.DeserializeObject<List<AdminModel>>(data); // "data" içindeki veriyi liste olarak alın

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "API HATASI");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,"Bir hata oluştu: "+ex.Message);
            }
            return adminModels;
        }



        public async Task<IActionResult> AdminLogin(string username,string password)
        {
            List<AdminModel> adminler = await GetAdminFromApi();
            var users= adminler.FirstOrDefault(admin => admin.Mail == username && admin.Sifre == password && admin.RolAdi=="Yönetici");
            if(users != null)
            {
                TempData["UserName"] = users.Adi;
                return RedirectToAction("AdminPage", "AdminPage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return View(adminler);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
