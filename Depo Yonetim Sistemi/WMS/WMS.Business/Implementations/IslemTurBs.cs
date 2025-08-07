using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.IslemTur;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class IslemTurBs : IIslemTurBs
    {
        private readonly IIslemTurRepository _repo;
        private readonly IMapper _mapper;

        public IslemTurBs(IIslemTurRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id < 0)
            {
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            }
            var ıslemtur = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(ıslemtur);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<IslemTurGetDto>>> GetIslemTurlerAsync(params string[] includeList)
        {
            var islemtur = await _repo.GetAllAsync(includeList: includeList);
            if (islemtur.Count > 0)
            {
                var returnList = _mapper.Map<List<IslemTurGetDto>>(islemtur);
                var response = ApiResponse<List<IslemTurGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<IslemTurGetDto>> IdGoreIslemTurGetirAsync(int IslemTurId, params string[] includeList)
        {
            if (IslemTurId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var islemtur = await _repo.IdGoreGetir(IslemTurId, includeList);
            if (islemtur != null)
            {
                var dto = _mapper.Map<IslemTurGetDto>(islemtur);
                return ApiResponse<IslemTurGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<IslemTur>> InsertAsync(IslemTurPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek islem bilgisi girmelisiniz..");

            var islemtur = _mapper.Map<IslemTur>(dto);
            var insertedIslem = await _repo.InsertAsync(islemtur);
            return ApiResponse<IslemTur>.Success(StatusCodes.Status201Created, insertedIslem);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(IslemTurPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Güncellenecek islem bilgisi girmelisiniz..");

            var islemtur = _mapper.Map<IslemTur>(entity);
            await _repo.UpdateAsync(islemtur);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
    }
}
