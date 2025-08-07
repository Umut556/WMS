using AutoMapper;
using WMS.Model.Dtos.Bolme;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class BolmeProfile : Profile
    {
        public BolmeProfile() {
            CreateMap<Bolme, BolmeGetDto>()
                .ForMember(dest => dest.BlokAdi,
                       opt => opt.MapFrom(src => src.Blok.BlokAdi))
                .ForMember(dest => dest.RafAdi,
                       opt => opt.MapFrom(src => src.Raf.RafAdi)); ;
            CreateMap<BolmePutDto, Bolme>();
            CreateMap<BolmePostDto, Bolme>();

        }
    }
}
