using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IMagazaRepository : IBaseRepository<Magaza>
    {
        Task<Magaza> IdGoreGetir(int magazaId, params string[] includeList);
        Task<List<Magaza>> AdaGoreGetir(string magazaAdi, params string[] includeList);
        Task<List<Magaza>> AdreseGoreGetir (string adres, params string[] includeList);
    }
}
