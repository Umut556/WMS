using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IKategoriRepository : IBaseRepository<Kategori>
    {
        Task<Kategori> IdGoreGetir (int kategoriId, params string[] includeList);
        Task<List<Kategori>> AdaGoreGetir (string kategoriAdi,  params string[] includeList);

    }
}
