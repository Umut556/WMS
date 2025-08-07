using AutoMapper;
using WMS.Model.Dtos.Blok;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class BlokProfile : Profile
    {
        public BlokProfile()
        {
            CreateMap<Blok, BlokGetDto>();
            CreateMap<BlokPutDto, Blok>();
            CreateMap<BlokPostDto, Blok>();
        }
    }
}
