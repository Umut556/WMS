using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.EF.Contexts;
using WMS.DataAccess.Interfaces;
using WMS.Model.Entities;

namespace WMS.DataAccess.EF.Repositories
{
    public class FabrikaRepository : BaseRepository<Fabrika, WMSDbContext>, IFabrikaRepository
    {
        public async Task<Fabrika> AdreseGoreGetir(string adres, params string[] includeList)
        {
            return await GetAsync(fabrika => fabrika.Adres == adres, includeList);

        }

        public async Task<Fabrika> IdGoreGetir(int fabrikaId, params string[] includeList)
        {
            return await GetAsync(fabrika => fabrika.FabrikaId == fabrikaId, includeList);
        }
    }
}
