using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Konum;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IKonumBs
    {
        Task<ApiResponse<KonumGetDto>> IdGoreKonumGetirAsync(int konumId, params string[] includeList);
        Task<ApiResponse<List<KonumGetDto>>> GetKonumlarAsync(params string[] includeList);
        Task<ApiResponse<Konum>> InsertAsync(KonumPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(KonumPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
