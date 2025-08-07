using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class GirisIslem : IEntity
    {
        public int GirisIslemId { get; set; }
        public int UrunID { get; set; }
        public int IslemTurID { get; set; }
        public int FabrikaID { get; set; }
        public int CalisanID { get; set; }
        public int UrunAdedi { get; set; }

        public string? Durum { get; set; }
        public DateTime IslemTarihi { get; set; }

        public Calisan Calisan { get; set; }
        public Fabrika Fabrika { get; set; }
        //public List<IslemTur>? IslemTurler { get; set; }
        public Urun Urun { get; set; }
        public IslemTur IslemTur { get; set; }
    }
}
