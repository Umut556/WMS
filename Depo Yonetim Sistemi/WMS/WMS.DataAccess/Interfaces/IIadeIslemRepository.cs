using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IIadeIslemRepository : IBaseRepository<IadeIslem>
    {
        Task<IadeIslem> IdGoreGetir(int iadeIslemId, params string[] includeList);

        Task<List<IadeIslem>> TariheGoreGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList);

    }
}
