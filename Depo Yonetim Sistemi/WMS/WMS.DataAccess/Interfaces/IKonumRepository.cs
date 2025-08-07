using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IKonumRepository : IBaseRepository<Konum>
    {
        Task<Konum> IdGoreGetir(int konumId, params string[] includeList);

    }
}
