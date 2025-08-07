using AutoMapper;
using WMS.Model.Dtos.CikisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class CikisIslemProfile : Profile
    {
        public CikisIslemProfile() {
            CreateMap<CikisIslem, CikisIslemGetDto>()
                .ForMember(dest => dest.UrunAdi,
                       opt => opt.MapFrom(src => src.Urun.Adi))
                .ForMember(dest => dest.IslemAdi,
                       opt => opt.MapFrom(src => src.IslemTur.IslemAdi))
                .ForMember(dest => dest.MagazaAdi,
                       opt => opt.MapFrom(src => src.Magaza.MagazaAdi))
                .ForMember(dest => dest.CalisanAdi,
                           opt => opt.MapFrom(src => src.Calisan.Adi));
            CreateMap<CikisIslemPutDto, CikisIslem>();
            CreateMap<CikisIslemPostDto, CikisIslem>();
        }
        
    }
}
