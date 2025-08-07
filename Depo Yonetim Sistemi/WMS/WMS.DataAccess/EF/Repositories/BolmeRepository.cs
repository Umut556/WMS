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
    public class BolmeRepository : BaseRepository<Bolme, WMSDbContext>, IBolmeRepository
    {
        public async Task<Bolme> IdGoreGetir(int bolmeId, params string[] includeList)
        {
            return await GetAsync(bolme => bolme.BolmeId == bolmeId, includeList);

        }

        public async Task<List<Bolme>> IsmeGoreGetir(string adi, params string[] includeList)
        {
            return await GetAllAsync(bolme => bolme.BolmeAdi == adi, includeList);

        }
    }
}
