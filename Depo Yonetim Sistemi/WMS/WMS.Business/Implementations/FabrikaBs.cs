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
using WMS.Model.Dtos.Fabrika;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class FabrikaBs : IFabrikaBs
    {
        private readonly IFabrikaRepository _repo;
        private readonly IMapper _mapper;

        public FabrikaBs(IFabrikaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<FabrikaGetDto>> AdreseGoreFabrikaGetir(string adres, params string[] includeList)
        {
            if (adres.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var fabrika = await _repo.AdreseGoreGetir(adres, includeList);
            if ( fabrika != null)
            {
                var returnList = _mapper.Map<FabrikaGetDto>(fabrika);
                return ApiResponse<FabrikaGetDto>.Success(StatusCodes.Status200OK,returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var fabrika = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(fabrika);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<FabrikaGetDto>>> FabrikalariGetir(params string[] includeList)
        {
            var fabrika = await _repo.GetAllAsync(includeList: includeList);
            if (fabrika.Count > 0)
            {
                var returnList = _mapper.Map<List<FabrikaGetDto>>(fabrika);
                var response = ApiResponse<List<FabrikaGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<FabrikaGetDto>> IdGoreFabrikaGetir(int fabrikaId, params string[] includeList)
        {
            if (fabrikaId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var fabrika = await _repo.IdGoreGetir(fabrikaId, includeList);
            if (fabrika != null)
            {
                var dto = _mapper.Map<FabrikaGetDto>(fabrika);
                return ApiResponse<FabrikaGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Fabrika>> Insert(FabrikaPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek fabrika bilgisi girmelisiniz..");


            var fabrika = _mapper.Map<Fabrika>(dto);

            var insertedFabrika = await _repo.InsertAsync(fabrika);
            return ApiResponse<Fabrika>.Success(StatusCodes.Status201Created, insertedFabrika);

        }

        public async Task<ApiResponse<NoData>> Update(FabrikaPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek fabrika bilgisi girmelisiniz..");

         
            var fabrika = _mapper.Map<Fabrika>(dto);
            await _repo.UpdateAsync(fabrika);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
