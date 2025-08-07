using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Islem;
using WMS.Model.Dtos.IslemTur;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemTurController : BaseController
    {
        private readonly IIslemTurBs _islemTurBs;
        public IslemTurController(IIslemTurBs islemTurBs)
        {
            _islemTurBs = islemTurBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetIslemTur()
        {
            var response = await _islemTurBs.GetIslemTurlerAsync();
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _islemTurBs.IdGoreIslemTurGetirAsync(id);
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIslemTur([FromBody] IslemTurPutDto dto)
        {
            var response = await _islemTurBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIslemTur(int id)
        {
            var response = await _islemTurBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewIslemTur([FromBody] IslemTurPostDto dto)
        {
            var response = await _islemTurBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.IslemTurId }, response.Data);

        }
    }
}
