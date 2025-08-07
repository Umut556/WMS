using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class Raf : IEntity
    {
        public int RafId { get; set; }
        public int BlokID { get; set; }
        public string? RafAdi { get; set; }
        public List<Bolme>? Bolmeler { get; set; }
        public Blok Blok { get; set; }
        //public Konum? Konum { get; set; }
        public List<Konum?> Konumlar { get; set; }
    }
}
