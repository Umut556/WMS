using AutoMapper;
using WMS.Model.Dtos.Raf;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class RafProfile : Profile
    {
        public RafProfile() {
            CreateMap<Raf, RafGetDto>()
                .ForMember(dest => dest.BlokAdi,
                       opt => opt.MapFrom(src => src.Blok.BlokAdi));
            CreateMap<RafPutDto, Raf>();
            CreateMap<RafPostDto, Raf>();
        }
    }
}
