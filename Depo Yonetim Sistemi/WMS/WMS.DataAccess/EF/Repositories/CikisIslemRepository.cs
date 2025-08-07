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
    public class CikisIslemRepository : BaseRepository<CikisIslem, WMSDbContext>, ICikisIslemRepository
    {
        public async Task<CikisIslem> IdGoreGetir(int cikisIslemId, params string[] includeList)
        {
            return await GetAsync(cikisIslem => cikisIslem.CikisIslemId  == cikisIslemId, includeList);

        }

        public async Task<List<CikisIslem>> TariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            return await GetAllAsync(cikisIslem => cikisIslem.IslemTarihi>=baslangicTarihi && cikisIslem.IslemTarihi <=bitisTarihi, includeList);

        }
    }
}
