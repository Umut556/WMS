using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.IadeIslem;

namespace WMS.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class IadeIslemController : BaseController
    {
        private readonly IIadeIslemBs _iadeIslemBs;

        public IadeIslemController(IIadeIslemBs ıadeIslemBs)
        {
            _iadeIslemBs = ıadeIslemBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetIadeIslemler()
        {
            var response = await _iadeIslemBs.GetIadeIslemlerAsync("Urun" ,"IslemTur", "Magaza", "Calisan");
            return await SendResponseAsync(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _iadeIslemBs.IdGoreIadeIslemGetirAsync(id, "Urun", "IslemTur", "Magaza", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpGet("Tarih")]
        public async Task<IActionResult> TariheGoreGetir([FromQuery] DateTime baslangic, [FromQuery] DateTime bitis)
        {
            var response = await _iadeIslemBs.TariheGoreIadeIslemGetirAsync(baslangic, bitis, "Urun", "IslemTur", "Magaza", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIAdeIslem([FromBody] IadeIslemPutDto dto)
        {
            var response = await _iadeIslemBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIadeIslem(int id)
        {
            var response = await _iadeIslemBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewIadeIslem([FromBody] IadeIslemPostDto dto)
        {
            var response = await _iadeIslemBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.IadeIslemId }, response.Data);

        }
    }
}
