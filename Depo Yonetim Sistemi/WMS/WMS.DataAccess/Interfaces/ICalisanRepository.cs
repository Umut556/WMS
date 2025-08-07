using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface ICalisanRepository : IBaseRepository<Calisan>
    {
        Task<Calisan> IdGoreGetir(int calisanId, params string[] includeList);
        Task<List<Calisan>> IsmeGoreGetir(string adi, params string[] includeList);
        Task<List<Calisan>> RoleGoreGetir(int rol, params string[] includeList);

    }
}
