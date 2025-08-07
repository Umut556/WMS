using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Magaza;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazaController : BaseController
    {
        private readonly IMagazaBs _magazaBs;

        public MagazaController(IMagazaBs magazaBs)
        {
            _magazaBs = magazaBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetMagazalar()
        {
            var response = await _magazaBs.GetMagazalarAsync();
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _magazaBs.IdGoreMagazaGetirAsync(id);
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _magazaBs.AdaGoreMagazaGetirAsync(isim);
            return await SendResponseAsync(response);
        }

        [HttpGet("adres")]
        public async Task<IActionResult> AdreseGoreGetir([FromQuery] string adres)
        {
            var response = await _magazaBs.AdreseGoreMagazaGetirAsync(adres);
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMagaza([FromBody] MagazaPutDto dto)
        {
            var response = await _magazaBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagaza(int id)
        {
            var response = await _magazaBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewMagaza([FromBody] MagazaPostDto dto)
        {
            var response = await _magazaBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.MagazaId }, response.Data);

        }

    }
}
