using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.IadeIslem
{
    public class IadeIslemGetDto : IDto
    {
        public int IadeIslemId { get; set; }
        //public int UrunID { get; set; }
        public string? UrunAdi { get; set; }

        public string? Durum { get; set; }
        //public int IslemTurID { get; set; }
        public string IslemAdi { get; set; }
        //public int MagazaID { get; set; }
        public string MagazaAdi { get; set; }
        //public int CalisanID { get; set; }
        public string? CalisanAdi { get; set; }
        public int UrunAdedi { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
