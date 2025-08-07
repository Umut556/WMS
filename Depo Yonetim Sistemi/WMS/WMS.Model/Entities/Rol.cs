using Infrastructure.Model;
namespace WMS.Model.Entities
{
    public class Rol : IEntity
    {
        public int RolId { get; set; }
        public string RolAdi { get; set; }

        public List<Calisan>? Calisanlar { get; set; }
    }
}
