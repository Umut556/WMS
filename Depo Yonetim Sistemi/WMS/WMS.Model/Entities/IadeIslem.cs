using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class IadeIslem : IEntity
    {
        public int IadeIslemId { get; set; }
        public int UrunID { get; set; }
        public int IslemTurID { get; set;}
        public int MagazaID { get; set;}
        public int CalisanID { get; set; }
        public int UrunAdedi { get;set;}
        public DateTime IslemTarihi { get; set; }
        public string? Durum { get; set; }

        public Calisan? Calisan { get; set; }
        public Magaza Magaza { get; set; }
        public Urun? Urun { get; set; }
       // public List<IslemTur>? IslemTurler { get; set; }
        public IslemTur IslemTur { get; set; }
    }
}
