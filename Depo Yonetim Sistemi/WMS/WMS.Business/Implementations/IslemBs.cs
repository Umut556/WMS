using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.GirisIslem;
using WMS.Model.Dtos.Islem;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class IslemBs : IIslemBs
    {
        private readonly IIslemRepository _repo;
        private readonly IMapper _mapper;

        public IslemBs(IIslemRepository repo, IMapper mapper)
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
            var islem = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(islem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<IslemGetDto>> IdGoreIslemGetir(int islemId, params string[] includeList)
        {
            if (islemId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var islem = await _repo.IdGoreGetir(islemId, includeList);
            if (islem != null)
            {
                var dto = _mapper.Map<IslemGetDto>(islem);
                return ApiResponse<IslemGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Islem>> InsertAsync(IslemPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek islem bilgisi girmelisiniz..");

            var islem = _mapper.Map<Islem>(dto);
            var insertedIslem = await _repo.InsertAsync(islem);
            return ApiResponse<Islem>.Success(StatusCodes.Status201Created, insertedIslem);

        }

        public  async Task<ApiResponse<List<IslemGetDto>>> IslemleriGetir(params string[] includeList)
        {
            var islem = await _repo.GetAllAsync(includeList: includeList);
            if (islem.Count > 0)
            {
                var returnList = _mapper.Map<List<IslemGetDto>>(islem);
                var response = ApiResponse<List<IslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<IslemGetDto>>> TariheGoreIslemGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            var islem = await _repo.TariheGoreGetir(baslangicTarihi, bitisTarihi);
            if (islem.Count > 0 && islem != null)
            {
                var returnList = _mapper.Map<List<IslemGetDto>>(islem);
                return ApiResponse<List<IslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(IslemPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Güncellenecek islem bilgisi girmelisiniz..");

            var islem = _mapper.Map<Islem>(entity);
            await _repo.UpdateAsync(islem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
