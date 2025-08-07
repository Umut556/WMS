using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WMS.DataAccess.EF.Contexts;
using WMS.DataAccess.Interfaces;
using WMS.Model.Entities;

namespace WMS.DataAccess.EF.Repositories
{
    public class CalisanRepository : BaseRepository<Calisan, WMSDbContext>, ICalisanRepository
    {
        public async Task<Calisan> IdGoreGetir(int calisanId, params string[] includeList)
        {
            return await GetAsync(add => add.CalisanId == calisanId, includeList);
        }

        public async Task<List<Calisan>> IsmeGoreGetir(string adi, params string[] includeList)
        {
            return await GetAllAsync(add => add.Adi == adi, includeList);
        }

        public async Task<List<Calisan>> RoleGoreGetir(int rol, params string[] includeList)
        {
            return await GetAllAsync(add => add.RolId == rol, includeList);
        }
    }
}
