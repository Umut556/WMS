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
    public class KategoriRepository : BaseRepository<Kategori, WMSDbContext>, IKategoriRepository
    {
        public async Task<List<Kategori>> AdaGoreGetir(string kategoriAdi, params string[] includeList)
        {
            return await GetAllAsync(kategori => kategori.KategoriAdi == kategoriAdi, includeList);
        }

        public async Task<Kategori> IdGoreGetir(int kategoriId, params string[] includeList)
        {
            return await GetAsync(kategori => kategori.KategoriId == kategoriId, includeList);
        }
    }
}
