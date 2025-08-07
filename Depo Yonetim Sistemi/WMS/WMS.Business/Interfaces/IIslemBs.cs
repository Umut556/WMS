using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Islem;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IIslemBs
    {
        Task<ApiResponse<IslemGetDto>> IdGoreIslemGetir (int islemId, params string[] includeList);
        Task<ApiResponse<List<IslemGetDto>>> TariheGoreIslemGetir (DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList); 
        
        Task<ApiResponse<List<IslemGetDto>>> IslemleriGetir (params string[] includeList);
        Task<ApiResponse<Islem>> InsertAsync(IslemPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(IslemPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
