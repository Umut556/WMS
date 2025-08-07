using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Dtos.Fabrika;
using WMS.Model.Entities;

namespace WMS.Business.Interfaces
{
    public interface IFabrikaBs
    {
        Task<ApiResponse<FabrikaGetDto>> IdGoreFabrikaGetir(int fabrikaId, params string[] includeList);
        Task<ApiResponse<FabrikaGetDto>> AdreseGoreFabrikaGetir(string adres, params string[] includeList);
        Task<ApiResponse<List<FabrikaGetDto>>> FabrikalariGetir(params string[] includeList);
        Task<ApiResponse<Fabrika>> Insert(FabrikaPostDto dto);
        Task<ApiResponse<NoData>> Update(FabrikaPutDto dto);
        Task<ApiResponse<NoData>> Delete(int id);
    
    
    }
}
