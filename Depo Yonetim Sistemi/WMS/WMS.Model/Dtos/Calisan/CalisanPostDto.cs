using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Calisan
{
    public class CalisanPostDto : IDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Maas { get; set; }
        public string TelefonNo { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public int RolId { get; set; }
    }
}
