using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IBlokRepository : IBaseRepository<Blok>
    {
        Task<Blok> IdGoreGetir(int blokId, params string[] includeList);
        Task<List<Blok>> IsmeGoreGetir(string blokadi, params string[] includeList);
        
    }
}
