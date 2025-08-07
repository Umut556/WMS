using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Kategori;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        private readonly IKategoriBs _kategoriBs;

        public KategoriController(IKategoriBs kategoriBs)
        {
            _kategoriBs = kategoriBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetKategoriler()
        {
            var response = await _kategoriBs.GetKategorilerAsync();
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _kategoriBs.IdGoreKategoriGetirAsync(id);
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _kategoriBs.IsmeGoreKategoriGetirAsync(isim);
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKategori([FromBody] KategoriPutDto dto)
        {
            var response = await _kategoriBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            var response = await _kategoriBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewKategori([FromBody] KategoriPostDto dto)
        {
            var response = await _kategoriBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.KategoriId }, response.Data);

        }
    }
}
