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
    public class RafRepository : BaseRepository<Raf, WMSDbContext>, IRafRepository
    {
        public async Task<Raf> IdGoreGetir(int rafId, params string[] includeList)
        {
            return await GetAsync(raf => raf.RafId == rafId, includeList);
        }

        public async Task<List<Raf>> IsmeGoreGetir(string adi, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.RafAdi.Contains(adi), includeList);
        }
    }
}
