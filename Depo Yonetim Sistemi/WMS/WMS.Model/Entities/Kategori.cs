using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class Kategori : IEntity
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set;}

        public List<Urun>? Urunler { get; set; }
    }
}
