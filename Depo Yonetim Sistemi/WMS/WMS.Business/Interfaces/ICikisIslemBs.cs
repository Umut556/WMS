using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.CikisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface ICikisIslemBs
    {
        Task<ApiResponse<CikisIslemGetDto>> IdGoreCikisIslemGetirAsync(int cikisIslemId, params string[] includeList);
        Task<ApiResponse<List<CikisIslemGetDto>>> TariheGoreCikisIslemGetirAsync(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList);
        Task<ApiResponse<List<CikisIslemGetDto>>> GetCikisIslemlerAsync(params string[] includeList);
        
        Task<ApiResponse<CikisIslem>> InsertAsync(CikisIslemPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CikisIslemPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
