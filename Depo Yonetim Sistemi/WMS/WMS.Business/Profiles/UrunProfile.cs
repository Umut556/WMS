using AutoMapper;
using WMS.Model.Dtos.Urun;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class UrunProfile : Profile
    {
        public UrunProfile() {
            CreateMap<Urun, UrunGetDto>()
                .ForMember(dest => dest.KategoriAdi,
                       opt => opt.MapFrom(src => src.Kategori.KategoriAdi));
            CreateMap<UrunPutDto, Urun>();
            CreateMap<UrunPostDto, Urun>();
        }
    }
}
