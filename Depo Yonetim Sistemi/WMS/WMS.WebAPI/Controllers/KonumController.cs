using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Blok;
using WMS.Model.Dtos.Konum;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonumController : BaseController
    {
        private readonly IKonumBs _konumBs;

        public KonumController(IKonumBs konumBs)
        {
            _konumBs = konumBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetKonumlar()
        {
            var response = await _konumBs.GetKonumlarAsync("Blok", "Bolme", "Raf");
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _konumBs.IdGoreKonumGetirAsync(id, "Blok", "Bolme", "Raf");
            return await SendResponseAsync(response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateKonum([FromBody] KonumPutDto dto)
        {
            var response = await _konumBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonum(int id)
        {
            var response = await _konumBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewKonum([FromBody] KonumPostDto dto)
        {
            var response = await _konumBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.KonumId }, response.Data);

        }
    }
}
