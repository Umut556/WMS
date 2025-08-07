using AutoMapper;
using WMS.Model.Dtos.GirisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class GirisIslemProfile : Profile
    {
        public GirisIslemProfile() {
            CreateMap<GirisIslem, GirisIslemGetDto>()
                .ForMember(dest => dest.UrunAdi,
                       opt => opt.MapFrom(src => src.Urun.Adi))
                .ForMember(dest => dest.IslemAdi,
                       opt => opt.MapFrom(src => src.IslemTur.IslemAdi))
                .ForMember(dest => dest.CalisanAdi,
                           opt => opt.MapFrom(src => src.Calisan.Adi));
            CreateMap<GirisIslemPutDto, GirisIslem>();
            CreateMap<GirisIslemPostDto, GirisIslem>();
        }
    }
}
