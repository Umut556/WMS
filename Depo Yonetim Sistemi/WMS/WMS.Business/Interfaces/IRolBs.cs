using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Rol;

namespace WMS.Business.Interfaces
{
    public interface IRolBs
    {
        Task<ApiResponse<RolGetDto>> IdGoreRolGetirAsync(int rolId, params string[] includeList);
        Task<ApiResponse<List<RolGetDto>>> GetRolesAsync(params string[] includeList);


    }
}
