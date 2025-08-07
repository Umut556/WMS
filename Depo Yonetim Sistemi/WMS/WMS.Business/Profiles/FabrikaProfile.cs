using AutoMapper;
using WMS.Model.Dtos.Fabrika;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class FabrikaProfile :Profile
    {
        public FabrikaProfile()
        {
            CreateMap<Fabrika, FabrikaGetDto>();
            CreateMap<FabrikaPutDto, Fabrika>();
            CreateMap<FabrikaPostDto, Fabrika>();
        }
    }
}
