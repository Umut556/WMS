using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Entities
{
    public class IslemTur : IEntity
    {
        public int IslemTurId { get; set; }
        public string IslemAdi { get; set; }

        public List<Islem>? Islemler { get; set; }
        public List<GirisIslem>? GirisIslemler { get; set; }
        public List<CikisIslem>? CikisIslemler { get; set; }
        public List<IadeIslem>? IadeIslemler { get; set; }
    }
}
