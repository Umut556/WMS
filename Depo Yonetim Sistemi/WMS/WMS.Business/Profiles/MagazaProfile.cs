using AutoMapper;
using WMS.Model.Dtos.Magaza;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class MagazaProfile : Profile
    {
        public MagazaProfile() {
            CreateMap<Magaza, MagazaGetDto>();
            CreateMap<MagazaPutDto, Magaza>();
            CreateMap<MagazaPostDto, Magaza>();
        }
    }
}
