using AutoMapper;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class CalisanProfile : Profile
    {
        public CalisanProfile()
        {
            CreateMap<Calisan, CalisanGetDto>()
                .ForMember(dest => dest.RolAdi,
                       opt => opt.MapFrom(src => src.Rol.RolAdi));

            CreateMap<CalisanPutDto, Calisan>();
            CreateMap<CalisanPostDto, Calisan>();
        }
       
    }
}
