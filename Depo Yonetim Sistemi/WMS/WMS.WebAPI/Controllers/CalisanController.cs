using Microsoft.AspNetCore.Mvc;
using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Model.Dtos.Calisan;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalisanController : BaseController
    {
        private readonly ICalisanBs _calisanBs;

        public CalisanController(ICalisanBs calisanBs)
        {
            _calisanBs = calisanBs;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalisanlar()
        {
            var response = await _calisanBs.GetCalisanlarAsync("Rol");
            return await SendResponseAsync(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _calisanBs.IdGoreCalisanGetirAsync(id,"Rol");
            return await SendResponseAsync(response);
        }

        [HttpGet("İsim")]
        public async Task<IActionResult> IsmeGoreGetir([FromQuery] string isim)
        {
            var response = await _calisanBs.IsimGoreCalisanGetirAsync(isim,"Rol");
            return await SendResponseAsync(response);
        }

        [HttpGet("Rol")]
        public async Task<IActionResult> RoleGoreGetir([FromQuery] int rol)
        {
            var response = await _calisanBs.RoleGoreCalisanGetirAsync(rol, "Rol");
            return await SendResponseAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCalisan([FromBody] CalisanPutDto dto)
        {
            var response = await _calisanBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalisan(int id)
        {
            var response = await _calisanBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewCalisan([FromBody] CalisanPostDto dto)
        {
            var response = await _calisanBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(IdGoreGetir), new { id = response.Data.CalisanId }, response.Data);

        }


    }
}
