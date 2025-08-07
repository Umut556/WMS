using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class Urun : IEntity
    {
        public int UrunId { get; set; }
        public int KategoriID { get; set; }
        public int StokMiktari { get; set; }
        public string? Adi { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public int KonumID { get; set; }

        public string? KartNumarasi { get; set; }
       // public List<IadeIslem>? IadeIslemler { get; set; }
        public IadeIslem IadeIslem { get; set; }
        public Kategori? Kategori { get; set; }
        //public List<CikisIslem>? CikisIslemler { get; set; }
        //public List<GirisIslem>? GirisIslemler { get; set; }
        public CikisIslem CikisIslem { get; set; }
        public GirisIslem GirisIslem { get; set; }

    }
}
