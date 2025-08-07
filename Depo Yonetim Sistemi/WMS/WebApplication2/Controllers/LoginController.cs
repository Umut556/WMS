using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WMS.Model.Entities;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://example.com/api/Urun");
            response.EnsureSuccessStatusCode();

            // Stream olarak içeriği oku
            Stream stream = await response.Content.ReadAsStreamAsync();

            // Stream'ı JSON formatındaki veriye dönüştür
            using (var reader = new StreamReader(stream))
            {
                string content = await reader.ReadToEndAsync();

                // JSON verisini istediğiniz modele dönüştür
                var products = JsonConvert.DeserializeObject<IEnumerable<Urun>>(content);

                return View(products);
            }
        }
    }
}
