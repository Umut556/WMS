using AutoMapper;
using WMS.Model.Dtos.Kategori;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class KategoriProfile : Profile
    {
        public KategoriProfile() {
            CreateMap<Kategori, KategoriGetDto>();
            CreateMap<KategoriPutDto, Kategori>();
            CreateMap<KategoriPostDto, Kategori>();
        }
    }
}
