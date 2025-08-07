using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IBolmeRepository : IBaseRepository<Bolme>
    {
        Task<Bolme> IdGoreGetir(int bolmeId, params string[] includeList);
        Task<List<Bolme>> IsmeGoreGetir(string adi, params string[] includeList);
   
    }
}
