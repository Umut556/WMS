using Infrastructure.Utilities.ApiResponses;
using WMS.Model.Dtos.Blok;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IBlokBs
    {
        Task<ApiResponse<BlokGetDto>> IdGoreBlokGetirAsync(int blokId, params string[] includeList);
        Task<ApiResponse<List<BlokGetDto>>> IsimGoreBlokGetirAsync(string adi, params string[] includeList);
        Task<ApiResponse<List<BlokGetDto>>> GetBloklarAsync(params string[] includeList);
        Task<ApiResponse<Blok>> InsertAsync(BlokPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(BlokPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
