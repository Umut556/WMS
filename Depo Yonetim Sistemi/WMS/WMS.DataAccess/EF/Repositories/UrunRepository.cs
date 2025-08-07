using Infrastructure.DataAccess.Implementations.EF;
using WMS.DataAccess.EF.Contexts;
using WMS.DataAccess.Interfaces;
using WMS.Model.Entities;

namespace WMS.DataAccess.EF.Repositories
{
    public class UrunRepository : BaseRepository<Urun, WMSDbContext>, IUrunRepository
    {
        public  async Task<Urun> IdGoreGetir(int urunId, params string[] includeList)
        {
            return await GetAsync(urun => urun.UrunId == urunId, includeList);
        }

        public async Task<List<Urun>> IsmeGoreGetir(string adi, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Adi.Contains(adi), includeList);
        }

        public async Task<List<Urun>> KayitTariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            return await GetAllAsync(cikisIslem => cikisIslem.KayıtTarihi >= baslangicTarihi && cikisIslem.KayıtTarihi <= bitisTarihi, includeList);
        }

       
    }
}
