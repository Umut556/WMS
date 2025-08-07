using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IRolRepository : IBaseRepository<Rol>
    {
        Task <Rol> IdGoreGetir (int rolId,params string[] includeList);

    }
}
