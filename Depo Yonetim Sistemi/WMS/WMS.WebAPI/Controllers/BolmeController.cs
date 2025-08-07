using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Blok;
using WMS.Model.Dtos.Bolme;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolmeController : BaseController
    {
        private readonly IBolmeBs _bolmeBs;

        public BolmeController(IBolmeBs bolmeBs)
        {
            _bolmeBs = bolmeBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetBolmeler()
        {
            var response = await _bolmeBs.GetBolmelerAsync("Blok","Raf");
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _bolmeBs.IdGoreBolmeGetirAsync(id, "Blok", "Raf");
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _bolmeBs.IsimGoreBolmeGetirAsync(isim, "Blok", "Raf");
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBolme([FromBody] BolmePutDto dto)
        {
            var response = await _bolmeBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolme(int id)
        {
            var response = await _bolmeBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewBolme([FromBody] BolmePostDto dto)
        {
            var response = await _bolmeBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.BolmeId }, response.Data);

        }
    }
}
