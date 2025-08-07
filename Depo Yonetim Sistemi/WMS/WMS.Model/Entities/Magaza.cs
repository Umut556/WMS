using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Entities
{
    public class Magaza : IEntity
    {

        public int MagazaId { get; set; }
        public string MagazaAdi { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Mail { get; set;}
        public string Sifre {get; set;}
        public List<IadeIslem>? IadeIslemler { get; set; }
        public List<CikisIslem>? CikisIslemler { get; set; }

    }
}
