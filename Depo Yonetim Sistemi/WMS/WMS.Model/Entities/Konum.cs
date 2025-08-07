using Infrastructure.Model;

namespace WMS.Model.Entities
{
    public class Konum : IEntity
    {
        public int KonumId { get; set; }
        public int BlokID { get; set; }
        public int RafID { get; set; }
        public int BolmeID { get; set;}

        public Bolme Bolme { get; set; }
        public Blok Blok { get; set; }
        public Raf Raf { get; set; }
        public Urun Urun { get; set; }



    }
}
