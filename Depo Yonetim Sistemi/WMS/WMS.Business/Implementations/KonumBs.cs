using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Konum;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class KonumBs : IKonumBs
    {
        private readonly IKonumRepository _repo;
        private readonly IMapper _mapper;

        public KonumBs(IKonumRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var konum = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(konum);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<KonumGetDto>>> GetKonumlarAsync(params string[] includeList)
        {
            var konumlar = await _repo.GetAllAsync(includeList: includeList);
            if (konumlar.Count > 0)
            {
                var returnList = _mapper.Map<List<KonumGetDto>>(konumlar);
                var response = ApiResponse<List<KonumGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<KonumGetDto>> IdGoreKonumGetirAsync(int konumId, params string[] includeList)
        {
            if (konumId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var konum = await _repo.IdGoreGetir(konumId, includeList);
            if (konum != null)
            {
                var dto = _mapper.Map<KonumGetDto>(konum);
                return ApiResponse<KonumGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Konum>> InsertAsync(KonumPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek konum bilgisi girmelisiniz..");

            var konum = _mapper.Map<Konum>(dto);

            var insertedKonum = await _repo.InsertAsync(konum);
            return ApiResponse<Konum>.Success(StatusCodes.Status201Created, insertedKonum);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(KonumPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek konum bilgisi girmelisiniz..");

            var konum = _mapper.Map<Konum>(dto);
            await _repo.UpdateAsync(konum);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
