using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Bolme;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IBolmeBs
    {
        Task<ApiResponse<BolmeGetDto>> IdGoreBolmeGetirAsync(int bolmeId, params string[] includeList);
        Task<ApiResponse<List<BolmeGetDto>>> IsimGoreBolmeGetirAsync(string adi, params string[] includeList);
        Task<ApiResponse<List<BolmeGetDto>>> GetBolmelerAsync(params string[] includeList);
        Task<ApiResponse<Bolme>> InsertAsync(BolmePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(BolmePutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
