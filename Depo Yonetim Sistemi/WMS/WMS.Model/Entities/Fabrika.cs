using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Entities
{
    public class Fabrika : IEntity
    {
        public int FabrikaId { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set;}

        public List<GirisIslem> GirisIslemler { get; set; }
    }
}
