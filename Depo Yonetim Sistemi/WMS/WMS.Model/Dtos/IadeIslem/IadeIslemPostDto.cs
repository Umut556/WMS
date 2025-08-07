using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.IadeIslem
{
    public class IadeIslemPostDto : IDto
    {
        public int UrunID { get; set; }
        public int IslemTurID { get; set; }

        public string? Durum { get; set; }
        public int MagazaID { get; set; }
        public int CalisanID { get; set; }
        public int UrunAdedi { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
