using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Entities;

namespace WMS.DataAccess.Interfaces
{
    public interface IIslemRepository: IBaseRepository<Islem>
    {
        Task<Islem> IdGoreGetir(int islemId, params string[] includeList);
        Task<List<Islem>> TariheGoreGetir (DateTime baslangicTarihi, DateTime bitisTarihi , params string[] includeList);


    }
}
