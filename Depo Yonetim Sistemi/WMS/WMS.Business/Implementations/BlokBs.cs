using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Blok;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class BlokBs : IBlokBs
    {
        private readonly IBlokRepository _repo;
        private readonly IMapper _mapper;

        public BlokBs(IBlokRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var blok = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(blok);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<BlokGetDto>>> GetBloklarAsync(params string[] includeList)
        {
            var bloklar = await _repo.GetAllAsync(includeList: includeList);
            if (bloklar.Count > 0)
            {
                var returnList = _mapper.Map<List<BlokGetDto>>(bloklar);
                var response = ApiResponse<List<BlokGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<BlokGetDto>> IdGoreBlokGetirAsync(int blokId, params string[] includeList)
        {
            if (blokId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var blok = await _repo.IdGoreGetir(blokId, includeList);
            if (blok != null)
            {
                var dto = _mapper.Map<BlokGetDto>(blok);
                return ApiResponse<BlokGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Blok>> InsertAsync(BlokPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek blok bilgisi girmelisiniz..");

            if (dto.BlokAdi.Length < 2)
                throw new BadRequestException("Blok ismi en az 3 harften oluşmalıdır..");


            var blok = _mapper.Map<Blok>(dto);

            var insertedBlok = await _repo.InsertAsync(blok);
            return ApiResponse<Blok>.Success(StatusCodes.Status201Created, insertedBlok);
        }

        public async Task<ApiResponse<List<BlokGetDto>>> IsimGoreBlokGetirAsync(string adi, params string[] includeList)
        {
            if (adi.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var bloklar = await _repo.IsmeGoreGetir(adi, includeList);
            if (bloklar.Count > 0 && bloklar != null)
            {
                var returnList = _mapper.Map<List<BlokGetDto>>(bloklar);
                return ApiResponse<List<BlokGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BlokPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek blok bilgisi girmelisiniz..");

            if (dto.BlokAdi.Length < 2)
                throw new BadRequestException("Blok ismi en az 3 harften oluşmalıdır..");

            var blok = _mapper.Map<Blok>(dto);
            await _repo.UpdateAsync(blok);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
