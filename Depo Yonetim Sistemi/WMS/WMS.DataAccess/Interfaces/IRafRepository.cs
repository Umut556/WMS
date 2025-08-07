using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IRafRepository : IBaseRepository<Raf>
    {
        Task<Raf> IdGoreGetir(int rafId, params string[] includeList);
        Task<List<Raf>> IsmeGoreGetir(string adi, params string[] includeList);
  
    }
}
