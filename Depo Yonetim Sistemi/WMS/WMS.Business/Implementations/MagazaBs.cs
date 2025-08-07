using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Dtos.Magaza;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class MagazaBs : IMagazaBs
    {
        private readonly IMagazaRepository _repo;
        private readonly IMapper _mapper;
        public MagazaBs(IMagazaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<MagazaGetDto>>> AdaGoreMagazaGetirAsync(string magazaAdi, params string[] includeList)
        {
            if (magazaAdi.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var magazalar = await _repo.AdaGoreGetir(magazaAdi, includeList);
            if (magazalar.Count > 0 && magazalar != null)
            {
                var returnList = _mapper.Map<List<MagazaGetDto>>(magazalar);
                return ApiResponse<List<MagazaGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<MagazaGetDto>>> AdreseGoreMagazaGetirAsync(string magazaAdresi, params string[] includeList)
        {
            var magazalar = await _repo.AdreseGoreGetir(magazaAdresi, includeList);
            if (magazalar.Count > 0)
            {
                var returnList = _mapper.Map<List<MagazaGetDto>>(magazalar);
                return ApiResponse<List<MagazaGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var magaza = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(magaza);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<MagazaGetDto>>> GetMagazalarAsync(params string[] includeList)
        {
            var magazalar = await _repo.GetAllAsync(includeList: includeList);
            if (magazalar.Count > 0)
            {
                var returnList = _mapper.Map<List<MagazaGetDto>>(magazalar);
                var response = ApiResponse<List<MagazaGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<MagazaGetDto>> IdGoreMagazaGetirAsync(int magazaId, params string[] includeList)
        {
            if (magazaId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var calisan = await _repo.IdGoreGetir(magazaId, includeList);
            if (calisan != null)
            {
                var dto = _mapper.Map<MagazaGetDto>(calisan);
                return ApiResponse<MagazaGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Magaza>> InsertAsync(MagazaPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek çalışan bilgisi girmelisiniz..");

            if (dto.MagazaAdi.Length < 2)
                throw new BadRequestException("Mağaza adı en az 3 harften oluşmalıdır..");

            if (dto.TelefonNo.Length <= 3)
                throw new BadRequestException("Çalışan en az 3 karakterden oluşmalıdır..");


            var magaza = _mapper.Map<Magaza>(dto);

            var insertedmagaza = await _repo.InsertAsync(magaza);
            return ApiResponse<Magaza>.Success(StatusCodes.Status201Created, insertedmagaza);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(MagazaPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek çalışan bilgisi girmelisiniz..");

            if (dto.MagazaAdi.Length < 2)
                throw new BadRequestException("Çalişan ismi en az 3 harften oluşmalıdır..");

            if (dto.TelefonNo.Length <= 3)
                throw new BadRequestException("Numara en az 3 karakterden oluşmalıdır..");

            if (dto.Adres.Length <= 3)
                throw new BadRequestException("Adres adı en az 3 karakterden oluşmalıdır..");

            var magaza = _mapper.Map<Magaza>(dto);
            await _repo.UpdateAsync(magaza);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
