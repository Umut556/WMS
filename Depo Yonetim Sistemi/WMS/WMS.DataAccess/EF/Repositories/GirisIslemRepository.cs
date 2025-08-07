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
    public class GirisIslemRepository : BaseRepository<GirisIslem, WMSDbContext>, IGirisIslemRepository
    {
        public async Task<GirisIslem> IdGoreGetir(int girisIslemId, params string[] includeList)
        {
            return await GetAsync(girisIslem => girisIslem.GirisIslemId == girisIslemId, includeList);

        }

        public async Task<List<GirisIslem>> TariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            return await GetAllAsync(girisIslem => girisIslem.IslemTarihi >= baslangicTarihi && girisIslem.IslemTarihi <= bitisTarihi, includeList);

        }
    }
}
