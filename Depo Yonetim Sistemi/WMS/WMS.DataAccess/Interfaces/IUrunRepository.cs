using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IUrunRepository : IBaseRepository<Urun>
    {
        Task<Urun> IdGoreGetir(int urunId, params string[] includeList);
        Task<List<Urun>> IsmeGoreGetir(string adi, params string[] includeList);

        Task<List<Urun>> KayitTariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi,  params string[] includeList);

    }
}
