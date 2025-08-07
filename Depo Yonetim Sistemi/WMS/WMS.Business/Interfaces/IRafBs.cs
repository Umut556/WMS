using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Raf;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IRafBs
    {
        Task<ApiResponse<RafGetDto>> IdGoreRafGetirAsync(int rafId, params string[] includeList);
        Task<ApiResponse<List<RafGetDto>>> IsimGoreRafGetirAsync(string adi, params string[] includeList);
        Task<ApiResponse<List<RafGetDto>>> GetRaflarAsync(params string[] includeList);
        Task<ApiResponse<Raf>> InsertAsync(RafPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(RafPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
