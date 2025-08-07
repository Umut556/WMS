using AutoMapper;
using WMS.Model.Dtos.IslemTur;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class IslemTurProfile : Profile
    {
        public IslemTurProfile() {
            CreateMap<IslemTur, IslemTurGetDto>();
            CreateMap<IslemTurPutDto, IslemTur>();
            CreateMap<IslemTurPostDto, IslemTur>();
        }
    }
}
