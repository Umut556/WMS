using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Magaza
{
    public class MagazaPutDto :IDto
    {
        public int MagazaId { get; set; }
        public string MagazaAdi { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
    }
}
