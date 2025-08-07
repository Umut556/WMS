using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Kategori;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IKategoriBs
    {
        Task<ApiResponse<KategoriGetDto>> IdGoreKategoriGetirAsync(int kategoriId, params string[] includeList);
        Task<ApiResponse<List<KategoriGetDto>>> IsmeGoreKategoriGetirAsync(string kategoriAdi, params string[] includeList);
        Task<ApiResponse<List<KategoriGetDto>>> GetKategorilerAsync(params string[] includeList);
        Task<ApiResponse<Kategori>> InsertAsync(KategoriPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(KategoriPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
