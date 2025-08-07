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
    public class RolRepository : BaseRepository<Rol, WMSDbContext>, IRolRepository
    {
        public async Task<Rol> IdGoreGetir(int rolId, params string[] includeList)
        {
            return await GetAsync(add => add.RolId == rolId, includeList);
        }
    }
}
