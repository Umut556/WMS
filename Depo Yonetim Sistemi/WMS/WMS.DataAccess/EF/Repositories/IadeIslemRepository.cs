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
    public class IadeIslemRepository : BaseRepository<IadeIslem, WMSDbContext>, IIadeIslemRepository
    {
        public async Task<IadeIslem> IdGoreGetir(int iadeIslemId, params string[] includeList)
        {
            return await GetAsync(iadeIslem => iadeIslem.IadeIslemId == iadeIslemId, includeList);

        }

        public async Task<List<IadeIslem>> TariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            return await GetAllAsync(iadeIslem => iadeIslem.IslemTarihi >= baslangicTarihi && iadeIslem.IslemTarihi <= bitisTarihi, includeList);

        }
    }
}
