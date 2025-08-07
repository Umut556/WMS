using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class Bolme: IEntity
    {
        public int BolmeId { get; set; }
        public int BlokID { get; set; }
        public int RafID { get; set; }
        public string? BolmeAdi { get; set; }


        public Raf? Raf { get; set; }
        public Blok? Blok { get; set; }
        public Konum? Konum{ get; set; }
         
        //public List<Konum?> Konumlar { get; set; }
    }
}
