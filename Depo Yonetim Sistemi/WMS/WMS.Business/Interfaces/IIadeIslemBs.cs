using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.IadeIslem;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IIadeIslemBs
    {
        Task<ApiResponse<IadeIslemGetDto>> IdGoreIadeIslemGetirAsync(int iadeIslemId, params string[] includeList);
        Task<ApiResponse<List<IadeIslemGetDto>>> GetIadeIslemlerAsync(params string[] includeList);
        Task<ApiResponse<List<IadeIslemGetDto>>> TariheGoreIadeIslemGetirAsync(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList);
        Task<ApiResponse<IadeIslem>> InsertAsync(IadeIslemPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(IadeIslemPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
