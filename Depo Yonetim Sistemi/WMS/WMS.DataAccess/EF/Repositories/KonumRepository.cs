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
    public class KonumRepository : BaseRepository<Konum, WMSDbContext>, IKonumRepository
    {
        public async Task<Konum> IdGoreGetir(int konumId, params string[] includeList)
        {
            return await GetAsync(knm => knm.KonumId == konumId, includeList);
        }
    }
}
