using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WMS.Business.CustomExceptions;
using WMS.Business.Interfaces;
using WMS.DataAccess.Interfaces;
using WMS.Model.Dtos.Kategori;
using WMS.Model.Entities;

namespace WMS.Business.Implementations
{
    public class KategoriBs : IKategoriBs
    {
        private readonly IKategoriRepository _repo;
        private readonly IMapper _mapper;
        public KategoriBs(IKategoriRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var kategori = await _repo.IdGoreGetir(id);
            await _repo.DeleteAsync(kategori);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<KategoriGetDto>>> GetKategorilerAsync(params string[] includeList)
        {
            var kategoriler = await _repo.GetAllAsync(includeList: includeList);
            if (kategoriler.Count > 0)
            {
                var returnList = _mapper.Map<List<KategoriGetDto>>(kategoriler);
                var response = ApiResponse<List<KategoriGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<KategoriGetDto>> IdGoreKategoriGetirAsync(int kategoriId, params string[] includeList)
        {
            if (kategoriId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var calisan = await _repo.IdGoreGetir(kategoriId, includeList);
            if (calisan != null)
            {
                var dto = _mapper.Map<KategoriGetDto>(calisan);
                return ApiResponse<KategoriGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Kategori>> InsertAsync(KategoriPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kategori bilgisi girmelisiniz..");

            if (dto.KategoriAdi.Length < 2)
                throw new BadRequestException("Çalışan ismi en az 3 harften oluşmalıdır..");

            var kategori = _mapper.Map<Kategori>(dto);

            var insertedkategori = await _repo.InsertAsync(kategori);
            return ApiResponse<Kategori>.Success(StatusCodes.Status201Created, kategori);
        }

        public async Task<ApiResponse<List<KategoriGetDto>>> IsmeGoreKategoriGetirAsync(string kategoriAdi, params string[] includeList)
        {
            if (kategoriAdi.Length < 2)
                throw new BadRequestException("Kategori ismi en az 3 harften oluşmalıdır");

            var kategoriler = await _repo.AdaGoreGetir(kategoriAdi, includeList);
            if (kategoriler.Count > 0 && kategoriler != null)
            {
                var returnList = _mapper.Map<List<KategoriGetDto>>(kategoriler);
                return ApiResponse<List<KategoriGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(KategoriPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek kategori bilgisi girmelisiniz..");

            if (dto.KategoriAdi.Length < 2)
                throw new BadRequestException("Kategori ismi en az 3 harften oluşmalıdır..");

            var kategori = _mapper.Map<Kategori>(dto);
            await _repo.UpdateAsync(kategori);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
