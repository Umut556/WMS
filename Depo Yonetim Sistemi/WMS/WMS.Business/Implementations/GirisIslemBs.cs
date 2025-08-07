using AutoMapper;
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
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.GirisIslem;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class GirisIslemBs : IGirisIslemBs
    {
        private readonly IGirisIslemRepository _repo;
        private readonly IMapper _mapper;

        public GirisIslemBs(IGirisIslemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> Delete(int id)
        {
            if(id<0)
            {
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            }
            var girisislem = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(girisislem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<GirisIslemGetDto>>> GirisIslemleriGetir(params string[] includeList)
        {
            var girisislem=await _repo.GetAllAsync(includeList: includeList);
            if(girisislem.Count>0)
            {
                var returnList = _mapper.Map<List<GirisIslemGetDto>>(girisislem);
                var response = ApiResponse<List<GirisIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<GirisIslemGetDto>> IdGoreGirisİslemGetir(int girisIslemid, params string[] includeList)
        {
            if (girisIslemid <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var girisislem = await _repo.IdGoreGetir(girisIslemid, includeList);
            if (girisislem != null)
            {
                var dto = _mapper.Map<GirisIslemGetDto>(girisislem);
                return ApiResponse<GirisIslemGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<GirisIslem>> Insert(GirisIslemPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek islem bilgisi girmelisiniz..");
          
            var girisislem=_mapper.Map<GirisIslem>(dto);
            var insertedGirisIslem= await _repo.InsertAsync(girisislem);
            return ApiResponse<GirisIslem>.Success(StatusCodes.Status201Created, insertedGirisIslem);
        }

        public async Task<ApiResponse<List<GirisIslemGetDto>>> TariheGoreGirisİslemGetir(DateTime baslangicTarihi, DateTime bitisTarihi, params string[] includeList)
        {
            var girisislem = await _repo.TariheGoreGetir(baslangicTarihi, bitisTarihi);
            if(girisislem.Count>0 && girisislem!=null)
            {
                var returnList = _mapper.Map<List<GirisIslemGetDto>>(girisislem);
                return ApiResponse<List<GirisIslemGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> Update(GirisIslemPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek islem bilgisi girmelisiniz..");

            var girisislem=_mapper.Map<GirisIslem>(dto);
            await _repo.UpdateAsync(girisislem);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
