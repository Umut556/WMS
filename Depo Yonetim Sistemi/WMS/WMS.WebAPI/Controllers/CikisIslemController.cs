using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.CikisIslem;
using WMS.Model.Dtos.GirisIslem;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CikisIslemController : BaseController
    {
        private readonly ICikisIslemBs _cikisIslemBs;

        public CikisIslemController(ICikisIslemBs cikisIslemBs)
        {
            _cikisIslemBs = cikisIslemBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetCikisIslemler()
        {
            var response = await _cikisIslemBs.GetCikisIslemlerAsync("Urun" ,"IslemTur" ,"Magaza", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _cikisIslemBs.IdGoreCikisIslemGetirAsync(id, "Urun", "IslemTur", "Magaza", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpGet("Tarih")]
        public async Task<IActionResult> TariheGoreGetir([FromQuery] DateTime baslangic, [FromQuery] DateTime bitis)
        {
            var response = await _cikisIslemBs.TariheGoreCikisIslemGetirAsync(baslangic, bitis, "Urun", "IslemTur", "Magaza", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCikisIslem([FromBody] CikisIslemPostDto dto)
        {
            var response = await _cikisIslemBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.CikisIslemId }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCikisIslem([FromBody] CikisIslemPutDto dto)
        {
            var response = await _cikisIslemBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var response = await _cikisIslemBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
