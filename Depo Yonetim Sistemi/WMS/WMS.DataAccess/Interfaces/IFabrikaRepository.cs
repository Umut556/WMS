using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IFabrikaRepository : IBaseRepository<Fabrika>
    {
        Task<Fabrika> IdGoreGetir(int fabrikaId, params string[] includeList);
        Task<Fabrika> AdreseGoreGetir (string adres,  params string[] includeList);
    }
}
