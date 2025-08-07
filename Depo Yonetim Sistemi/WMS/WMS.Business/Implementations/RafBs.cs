using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Raf;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class RafBs : IRafBs
    {
        private readonly IRafRepository _repo;
        private readonly IMapper _mapper;
        public RafBs(IRafRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var raf = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(raf);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<RafGetDto>>> GetRaflarAsync(params string[] includeList)
        {
            var raflar = await _repo.GetAllAsync(includeList: includeList);
            if (raflar.Count > 0)
            {
                var returnList = _mapper.Map<List<RafGetDto>>(raflar);
                var response = ApiResponse<List<RafGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<RafGetDto>> IdGoreRafGetirAsync(int rafId, params string[] includeList)
        {
            if (rafId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var raf = await _repo.IdGoreGetir(rafId, includeList);
            if (raf != null)
            {
                var dto = _mapper.Map<RafGetDto>(raf);
                return ApiResponse<RafGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Raf>> InsertAsync(RafPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek raf bilgisi girmelisiniz..");

            var raf = _mapper.Map<Raf>(dto);

            var insertedRaf = await _repo.InsertAsync(raf);
            return ApiResponse<Raf>.Success(StatusCodes.Status201Created, insertedRaf);
        }

        public async Task<ApiResponse<List<RafGetDto>>> IsimGoreRafGetirAsync(string adi, params string[] includeList)
        {
            if (adi.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var raflar = await _repo.IsmeGoreGetir(adi, includeList);
            if (raflar.Count > 0 && raflar != null)
            {
                var returnList = _mapper.Map<List<RafGetDto>>(raflar);
                return ApiResponse<List<RafGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(RafPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek raf bilgisi girmelisiniz..");

            var raf = _mapper.Map<Raf>(dto);
            await _repo.UpdateAsync(raf);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
