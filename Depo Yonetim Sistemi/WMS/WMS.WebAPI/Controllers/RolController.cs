using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Business.Interfaces;
using WMS.Model.Entities;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : BaseController
    {
        private readonly IRolBs _rolBs;

        public RolController(IRolBs rolBs)
        {
            _rolBs = rolBs;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> IdGoreGetir([FromRoute] int id)
        {
            var response = await _rolBs.IdGoreRolGetirAsync(id);
            return await SendResponseAsync(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoller()
        {
            var response = await _rolBs.GetRolesAsync();
            return await SendResponseAsync(response);
        }

    }
}
