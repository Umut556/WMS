using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.IslemTur;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IIslemTurBs
    {
        Task<ApiResponse<IslemTurGetDto>> IdGoreIslemTurGetirAsync(int IslemTurId, params string[] includeList);
        Task<ApiResponse<List<IslemTurGetDto>>> GetIslemTurlerAsync(params string[] includeList);
        Task<ApiResponse<IslemTur>> InsertAsync(IslemTurPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(IslemTurPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
