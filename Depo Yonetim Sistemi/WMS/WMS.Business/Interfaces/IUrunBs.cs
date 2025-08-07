using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Urun;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IUrunBs
    {
        Task<ApiResponse<UrunGetDto>> IdGoreUrunGetirAsync(int urunId, params string[] includeList);
        Task<ApiResponse<List<UrunGetDto>>> IsimGoreUrunGetirAsync(string adi, params string[] includeList);
        Task<ApiResponse<List<UrunGetDto>>> KayitTariheGoreUrunGetirAsync(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList);
        Task<ApiResponse<List<UrunGetDto>>> GetUrunlerAsync(params string[] includeList);
        Task<ApiResponse<Urun>> InsertAsync(UrunPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(UrunPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
