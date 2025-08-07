using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Calisan;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class CalisanBs : ICalisanBs
    {
        private readonly ICalisanRepository _repo;
        private readonly IMapper _mapper;
        public CalisanBs(ICalisanRepository repo, IMapper mapper)
        {
            _repo= repo;
            _mapper= mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {

            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var customer = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(customer);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CalisanPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek çalışan bilgisi girmelisiniz..");

            if (dto.Adi.Length < 2)
                throw new BadRequestException("Çalişan ismi en az 3 harften oluşmalıdır..");

            if (dto.Soyadi.Length < 2)
                throw new BadRequestException("Çalışan soyismi en az 3 harften oluşmalıdır..");

            if (dto.TelefonNo.Length <= 3)
                throw new BadRequestException("Numara en az 3 karakterden oluşmalıdır..");

            if (dto.Adres.Length <= 3)
                throw new BadRequestException("Adres adı en az 3 karakterden oluşmalıdır..");

            var calisan= _mapper.Map<Calisan>(dto);
            await _repo.UpdateAsync(calisan);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }


        public async Task<ApiResponse<Calisan>> InsertAsync(CalisanPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek çalışan bilgisi girmelisiniz..");

            if (dto.Adi.Length < 2)
                throw new BadRequestException("Çalışan ismi en az 3 harften oluşmalıdır..");

            if (dto.Soyadi.Length < 2)
                throw new BadRequestException("Çalışan soyismi en az 3 harften oluşmalıdır..");

            if (dto.TelefonNo.Length <= 3)
                throw new BadRequestException("Çalışan en az 3 karakterden oluşmalıdır..");


            var calisan = _mapper.Map<Calisan>(dto);

            var insertedCalisan = await _repo.InsertAsync(calisan);
            return ApiResponse<Calisan>.Success(StatusCodes.Status201Created, insertedCalisan);
        }


        public async Task<ApiResponse<List<CalisanGetDto>>> GetCalisanlarAsync(params string[] includeList)
        {
            var calisanlar = await _repo.GetAllAsync(includeList: includeList);
            if (calisanlar.Count > 0)
            {
                var returnList = _mapper.Map<List<CalisanGetDto>>(calisanlar);
                var response = ApiResponse<List<CalisanGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }


        public async Task<ApiResponse<List<CalisanGetDto>>> IsimGoreCalisanGetirAsync(string adi, params string[] includeList)
        {
            if (adi.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var calisanlar = await _repo.IsmeGoreGetir(adi, includeList);
            if (calisanlar.Count > 0 && calisanlar != null)
            {
                var returnList = _mapper.Map<List<CalisanGetDto>>(calisanlar);
                return ApiResponse<List<CalisanGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CalisanGetDto>>> RoleGoreCalisanGetirAsync(int rol,params string[] includeList)
        {
            var calisanlar = await _repo.RoleGoreGetir(rol, includeList);
            if (calisanlar.Count > 0)
            {
                var returnList = _mapper.Map<List<CalisanGetDto>>(calisanlar);
                return ApiResponse<List<CalisanGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<CalisanGetDto>> IdGoreCalisanGetirAsync(int calisanId, params string[] includeList)
        {
            if (calisanId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var calisan = await _repo.IdGoreGetir(calisanId, includeList);
            if (calisan != null)
            {
                var dto = _mapper.Map<CalisanGetDto>(calisan);
                return ApiResponse<CalisanGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }
    }
}
