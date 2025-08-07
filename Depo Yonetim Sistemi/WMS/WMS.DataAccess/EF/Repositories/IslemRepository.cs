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
    public class IslemRepository : BaseRepository<Islem, WMSDbContext>, IIslemRepository
    {
        public async Task<Islem> IdGoreGetir(int islemId, params string[] includeList)
        {
            return await GetAsync(islem => islem.IslemId == islemId, includeList);

        }

        public async Task<List<Islem>> TariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            return await GetAllAsync(islem => islem.IslemTarihi >= baslangicTarihi && islem.IslemTarihi <= bitisTarihi, includeList);

        }
    }
}
