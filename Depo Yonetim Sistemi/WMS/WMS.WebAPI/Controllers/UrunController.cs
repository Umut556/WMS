using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Urun;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : BaseController
    {
        private readonly IUrunBs _urunBs;

        public UrunController(IUrunBs urunBs)
        {
            _urunBs = urunBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrunler()
        {
            var response = await _urunBs.GetUrunlerAsync("Kategori");
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _urunBs.IdGoreUrunGetirAsync(id, "Kategori");
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _urunBs.IsimGoreUrunGetirAsync(isim, "Kategori");
            return await SendResponseAsync(response);
        }

        [HttpGet("Tarih")]
        public async Task<IActionResult> TariheGoreGetir([FromQuery] DateTime baslangic, [FromQuery] DateTime bitis)
        {
            var response = await _urunBs.KayitTariheGoreUrunGetirAsync(baslangic, bitis, "Kategori");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUrun([FromBody] UrunPostDto dto)
        {
            var response = await _urunBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.UrunId }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUrun([FromBody] UrunPutDto dto)
        {
            var response = await _urunBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var response = await _urunBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
