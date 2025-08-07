using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.IadeIslem;
using WMS.Model.Dtos.Islem;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class IadeIslemBs : IIadeIslemBs
    {
        private readonly IIadeIslemRepository _repo;
        private readonly IMapper _mapper;
        public IadeIslemBs(IIadeIslemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var iadeIslem = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(iadeIslem);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<IadeIslemGetDto>>> GetIadeIslemlerAsync(params string[] includeList)
        {
            var iadeIslemler = await _repo.GetAllAsync(includeList: includeList);
            if (iadeIslemler.Count > 0)
            {
                var returnList = _mapper.Map<List<IadeIslemGetDto>>(iadeIslemler);
                var response = ApiResponse<List<IadeIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<IadeIslemGetDto>> IdGoreIadeIslemGetirAsync(int iadeIslemId, params string[] includeList)
        {
            if (iadeIslemId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var iadeIslem = await _repo.IdGoreGetir(iadeIslemId, includeList);
            if (iadeIslem != null)
            {
                var dto = _mapper.Map<IadeIslemGetDto>(iadeIslem);
                return ApiResponse<IadeIslemGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async  Task<ApiResponse<IadeIslem>> InsertAsync(IadeIslemPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek çalışan bilgisi girmelisiniz..");

            var iadeIslem = _mapper.Map<IadeIslem>(dto);

            var insertedIadeIslem = await _repo.InsertAsync(iadeIslem);
            return ApiResponse<IadeIslem>.Success(StatusCodes.Status201Created, insertedIadeIslem);
        }

        public async Task<ApiResponse<List<IadeIslemGetDto>>> TariheGoreIadeIslemGetirAsync(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            var islem = await _repo.TariheGoreGetir(baslangicTarihi, bitisTarihi);
            if (islem.Count > 0 && islem != null)
            {
                var returnList = _mapper.Map<List<IadeIslemGetDto>>(islem);
                return ApiResponse<List<IadeIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(IadeIslemPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek iade işlem bilgisi girmelisiniz..");

            var iadeIslem = _mapper.Map<IadeIslem>(dto);
            await _repo.UpdateAsync(iadeIslem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
