using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Dtos.Rol;
using WMS.Model.Entities;

namespace WMS.Business.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolGetDto>();
        }
    }
}
