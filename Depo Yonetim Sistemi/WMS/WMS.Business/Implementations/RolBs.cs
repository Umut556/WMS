using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Metrics;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Rol;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class RolBs : IRolBs
    {
        private readonly IRolRepository _repo;
        private readonly IMapper _mapper;

        public RolBs(IRolRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<RolGetDto>> IdGoreRolGetirAsync(int rolId, params string[] includeList)
        {
            if (rolId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var rol = await _repo.IdGoreGetir(rolId, includeList);
            if (rol != null)
            {
                var dto = _mapper.Map<RolGetDto>(rol);
                return ApiResponse<RolGetDto>.Success(StatusCodes.Status200OK,dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<RolGetDto>>> GetRolesAsync(params string[] includeList)
        {
            var roller = await _repo.GetAllAsync(includeList: includeList);
            if (roller.Count > 0)
            {
                var returnList = _mapper.Map<List<RolGetDto>>(roller);
                var response = ApiResponse<List<RolGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }
    }
}
