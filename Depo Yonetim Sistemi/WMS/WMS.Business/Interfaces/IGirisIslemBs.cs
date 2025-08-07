using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Dtos.GirisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IGirisIslemBs
    {
        Task<ApiResponse<GirisIslemGetDto>> IdGoreGirisİslemGetir(int girisIslemid, params string[] includeList);
        Task<ApiResponse<List<GirisIslemGetDto>>> TariheGoreGirisİslemGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList);
        Task<ApiResponse<List<GirisIslemGetDto>>> GirisIslemleriGetir(params string[] includeList);
        Task<ApiResponse<GirisIslem>> Insert(GirisIslemPostDto dto);
        Task<ApiResponse<NoData>> Update(GirisIslemPutDto dto);
        Task<ApiResponse<NoData>> Delete(int id);

    
    
    
    }
}
