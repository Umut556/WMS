using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Blok;
using WMS.Model.Dtos.Calisan;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlokController : BaseController
    {
        private readonly IBlokBs _blokBs;

        public BlokController(IBlokBs blokBs)
        {
            _blokBs = blokBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetBloklar()
        {
            var response = await _blokBs.GetBloklarAsync();
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _blokBs.IdGoreBlokGetirAsync(id);
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _blokBs.IsimGoreBlokGetirAsync(isim);
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlok([FromBody] BlokPutDto dto)
        {
            var response = await _blokBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlok(int id)
        {
            var response = await _blokBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewBlok([FromBody] BlokPostDto dto)
        {
            var response = await _blokBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.BlokId }, response.Data);

        }
    }
}
