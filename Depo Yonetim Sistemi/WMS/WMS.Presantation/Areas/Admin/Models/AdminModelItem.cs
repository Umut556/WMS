namespace WMS.MvcUI.Areas.Admin.Models
{
    public class AdminModelItem
    {
        public int CalisanId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Maas { get; set; }
        public string TelefonNo { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        //public int RolId { get; set; }
        public string RolAdi { get; set; }
    }
}
