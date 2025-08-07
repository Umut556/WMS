using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Blok;
using WMS.Model.Dtos.Raf;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RafController : BaseController
    {
        private readonly IRafBs _rafBs;

        public RafController(IRafBs rafBs)
        {
            _rafBs = rafBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetRaflar()
        {
            var response = await _rafBs.GetRaflarAsync("Blok");
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _rafBs.IdGoreRafGetirAsync(id, "Blok");
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _rafBs.IsimGoreRafGetirAsync(isim, "Blok");
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRaf([FromBody] RafPutDto dto)
        {
            var response = await _rafBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaf(int id)
        {
            var response = await _rafBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewRaf([FromBody] RafPostDto dto)
        {
            var response = await _rafBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.RafId }, response.Data);

        }
    }
}
