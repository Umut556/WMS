using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Urun
{
    public class UrunPostDto : IDto
    {
        public int KategoriID { get; set; }
        public int StokMiktari { get; set; }
        public string? Adi { get; set; }
        public string? KartNumarasi { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public int KonumID { get; set; }
    }
}
