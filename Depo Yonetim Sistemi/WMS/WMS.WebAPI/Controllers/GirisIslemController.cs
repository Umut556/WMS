using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.GirisIslem;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisIslemController : BaseController
    {
        private readonly IGirisIslemBs _girisIslemBs;

        public GirisIslemController(IGirisIslemBs girisIslemBs)
        {
            _girisIslemBs = girisIslemBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetGirisIslemler()
        {
            var response= await _girisIslemBs.GirisIslemleriGetir("Urun", "IslemTur", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response=await _girisIslemBs.IdGoreGirisİslemGetir(id, "Urun", "IslemTur", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpGet("Tarih")]
        public async Task<IActionResult> TariheGoreGetir([FromQuery] DateTime baslangic, [FromQuery] DateTime bitis)
        {
            var response = await _girisIslemBs.TariheGoreGirisİslemGetir(baslangic, bitis, "Urun", "IslemTur", "Calisan");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveGirisIslem([FromBody] GirisIslemPostDto dto)
        {
            var response=await _girisIslemBs.Insert(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.GirisIslemId }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGirisIslem([FromBody] GirisIslemPutDto dto)
        {
            var response = await _girisIslemBs.Update(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var response = await _girisIslemBs.Delete(id);

            return await SendResponseAsync(response);
        }
    }
}
