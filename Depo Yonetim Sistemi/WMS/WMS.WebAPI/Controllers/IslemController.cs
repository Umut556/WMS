using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Islem;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemController : BaseController
    {
        private readonly IIslemBs _islemBs;

        public IslemController(IIslemBs islemBs)
        {
            _islemBs = islemBs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _islemBs.IdGoreIslemGetir(id, "IslemTur");
            return await SendResponseAsync(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetIslem()
        {
            var response = await _islemBs.IslemleriGetir("IslemTur");
            return await SendResponseAsync(response);
        }

        [HttpGet("Tarih")]
        public async Task<IActionResult> TariheGoreGetir([FromQuery] DateTime baslangic, [FromQuery] DateTime bitis)
        {
            var response = await _islemBs.TariheGoreIslemGetir(baslangic, bitis, "IslemTur");
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCalisan([FromBody] IslemPutDto dto)
        {
            var response = await _islemBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var response = await _islemBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewIslem([FromBody] IslemPostDto dto)
        {
            var response = await _islemBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.IslemTurID }, response.Data);

        }
    }
}
