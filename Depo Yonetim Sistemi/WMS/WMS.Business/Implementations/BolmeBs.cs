using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Bolme;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class BolmeBs : IBolmeBs
    {
        private readonly IBolmeRepository _repo;
        private readonly IMapper _mapper;

        public BolmeBs(IBolmeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var bolme = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(bolme);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<BolmeGetDto>>> GetBolmelerAsync(params string[] includeList)
        {
            var bolmeler = await _repo.GetAllAsync(includeList: includeList);
            if (bolmeler.Count > 0)
            {
                var returnList = _mapper.Map<List<BolmeGetDto>>(bolmeler);
                var response = ApiResponse<List<BolmeGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<BolmeGetDto>> IdGoreBolmeGetirAsync(int bolmeId, params string[] includeList)
        {
            if (bolmeId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var bolme = await _repo.IdGoreGetir(bolmeId, includeList);
            if (bolme != null)
            {
                var dto = _mapper.Map<BolmeGetDto>(bolme);
                return ApiResponse<BolmeGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Bolme>> InsertAsync(BolmePostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek bolme bilgisi girmelisiniz..");

            var bolme = _mapper.Map<Bolme>(dto);

            var insertedBolme = await _repo.InsertAsync(bolme);
            return ApiResponse<Bolme>.Success(StatusCodes.Status201Created, insertedBolme);
        }

        public async Task<ApiResponse<List<BolmeGetDto>>> IsimGoreBolmeGetirAsync(string adi, params string[] includeList)
        {
            if (adi.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var bolmeler = await _repo.IsmeGoreGetir(adi, includeList);
            if (bolmeler.Count > 0 && bolmeler != null)
            {
                var returnList = _mapper.Map<List<BolmeGetDto>>(bolmeler);
                return ApiResponse<List<BolmeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BolmePutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek bolme bilgisi girmelisiniz..");

            var bolme = _mapper.Map<Bolme>(dto);
            await _repo.UpdateAsync(bolme);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
