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
    public class MagazaRepository : BaseRepository<Magaza, WMSDbContext>, IMagazaRepository
    {
        public async Task<List<Magaza>> AdaGoreGetir(string magazaAdi, params string[] includeList)
        {
            return await GetAllAsync(mgz => mgz.MagazaAdi.Contains(magazaAdi), includeList);

        }

        public async Task<List<Magaza>> AdreseGoreGetir(string adres, params string[] includeList)
        {   
            return await GetAllAsync(urun => urun.Adres == adres, includeList);
        }

        public async Task<Magaza> IdGoreGetir(int magazaId, params string[] includeList)
        {
            return await GetAsync(urun => urun.MagazaId == magazaId, includeList);
        }
    }
}
