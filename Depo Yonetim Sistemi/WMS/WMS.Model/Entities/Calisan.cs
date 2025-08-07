using Infrastructure.Model;
namespace WMS.Model.Entities
{
    public class Calisan : IEntity
    {
        public int CalisanId { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int Maas { get;  set; }
        public string? TelefonNo { get; set; }
        public string? Adres { get; set; }
        public string? Mail { get; set; }
        public string? Sifre { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public int RolId { get; set; }

        public Rol? Rol { get; set;}
        public List<CikisIslem>? CikisIslemler { get; set; }
        public List<IadeIslem>? IadeIslemler { get; set; }
        public List<GirisIslem>? GirisIslemler { get; set; }

    }
}
