using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Magaza;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IMagazaBs
    {
        Task<ApiResponse<MagazaGetDto>> IdGoreMagazaGetirAsync(int magazaId, params string[] includeList);
        Task<ApiResponse<List<MagazaGetDto>>> AdaGoreMagazaGetirAsync(string magazaAdi, params string[] includeList);
        Task<ApiResponse<List<MagazaGetDto>>> GetMagazalarAsync(params string[] includeList);
        Task<ApiResponse<List<MagazaGetDto>>> AdreseGoreMagazaGetirAsync(string magazaAdresi, params string[] includeList);
        Task<ApiResponse<Magaza>> InsertAsync(MagazaPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(MagazaPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
