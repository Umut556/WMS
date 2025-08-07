using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface ICalisanBs
    {
        Task<ApiResponse<CalisanGetDto>> IdGoreCalisanGetirAsync(int calisanId, params string[] includeList);
        Task<ApiResponse<List<CalisanGetDto>>> IsimGoreCalisanGetirAsync(string adi, params string[] includeList);
        Task<ApiResponse<List<CalisanGetDto>>> GetCalisanlarAsync(params string[] includeList);
        Task<ApiResponse<List<CalisanGetDto>>> RoleGoreCalisanGetirAsync(int rol,params string[] includeList);
        Task<ApiResponse<Calisan>> InsertAsync(CalisanPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CalisanPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);


    }
}
