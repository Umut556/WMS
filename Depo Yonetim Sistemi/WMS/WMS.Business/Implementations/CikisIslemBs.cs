using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.CikisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class CikisIslemBs : ICikisIslemBs
    {

        private readonly ICikisIslemRepository _repo;
        private readonly IMapper _mapper;
        public CikisIslemBs(ICikisIslemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var cikisIslem = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(cikisIslem);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CikisIslemGetDto>>> GetCikisIslemlerAsync(params string[] includeList)
        {
            var cikisIslemler = await _repo.GetAllAsync(includeList: includeList);
            if (cikisIslemler.Count > 0)
            {
                var returnList = _mapper.Map<List<CikisIslemGetDto>>(cikisIslemler);
                var response = ApiResponse<List<CikisIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<CikisIslemGetDto>> IdGoreCikisIslemGetirAsync(int cikisIslemId, params string[] includeList)
        {
            if (cikisIslemId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var calisan = await _repo.IdGoreGetir(cikisIslemId, includeList);
            if (calisan != null)
            {
                var dto = _mapper.Map<CikisIslemGetDto>(calisan);
                return ApiResponse<CikisIslemGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<CikisIslem>> InsertAsync(CikisIslemPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek çalışan bilgisi girmelisiniz..");

            var cikisIslem = _mapper.Map<CikisIslem>(dto);

            var insertedcikisIslem = await _repo.InsertAsync(cikisIslem);
            return ApiResponse<CikisIslem>.Success(StatusCodes.Status201Created, insertedcikisIslem);
        }

        public async Task<ApiResponse<List<CikisIslemGetDto>>> TariheGoreCikisIslemGetirAsync(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            var islem = await _repo.TariheGoreGetir(baslangicTarihi, bitisTarihi);
            if (islem.Count > 0 && islem != null)
            {
                var returnList = _mapper.Map<List<CikisIslemGetDto>>(islem);
                return ApiResponse<List<CikisIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CikisIslemPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek iade işlem bilgisi girmelisiniz..");

            var iadeIslem = _mapper.Map<CikisIslem>(dto);
            await _repo.UpdateAsync(iadeIslem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
