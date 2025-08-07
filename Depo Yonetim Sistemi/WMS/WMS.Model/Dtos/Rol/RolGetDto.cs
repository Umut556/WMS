using Infrastructure.Model;
namespace WMS.Model.Dtos.Rol
{
    public class RolGetDto : IDto
    {
        public int RolId { get; set; }
        public string RolAdi { get; set; }
    }
}
