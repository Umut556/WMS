using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Fabrika;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabrikaController : BaseController
    {
        private readonly IFabrikaBs _fabrikaBs;
        public FabrikaController(IFabrikaBs fabrikaBs)
        {
            _fabrikaBs = fabrikaBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalisanlar()
        {
            var response = await _fabrikaBs.FabrikalariGetir();
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _fabrikaBs.IdGoreFabrikaGetir(id);
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> AdreseGoreGetir([FromQuery] string adres)
        {
            var response = await _fabrikaBs.AdreseGoreFabrikaGetir(adres);
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFabrika([FromBody] FabrikaPutDto dto)
        {
            var response = await _fabrikaBs.Update(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabrika(int id)
        {
            var response = await _fabrikaBs.Delete(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewFabrika([FromBody] FabrikaPostDto dto)
        {
            var response = await _fabrikaBs.Insert(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.FabrikaId }, response.Data);

        }
    }
}
