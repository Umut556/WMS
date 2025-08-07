using WMS.Business.Implementations;
using WMS.Business.Interfaces;
using WMS.Business.Profiles;
using WMS.DataAccess.EF.Repositories;
using WMS.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace WMS.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RolProfile));

            services.AddScoped<IBlokBs, BlokBs>();
            services.AddScoped<IBlokRepository, BlokRepository>();

            services.AddScoped<IBolmeBs, BolmeBs>();
            services.AddScoped<IBolmeRepository, BolmeRepository>();

            services.AddScoped<ICikisIslemBs, CikisIslemBs>();
            services.AddScoped<ICikisIslemRepository, CikisIslemRepository>();

            services.AddScoped<IFabrikaBs, FabrikaBs>();
            services.AddScoped<IFabrikaRepository, FabrikaRepository>();

            services.AddScoped<IGirisIslemBs, GirisIslemBs>();
            services.AddScoped<IGirisIslemRepository, GirisIslemRepository>();

            services.AddScoped<IIadeIslemBs, IadeIslemBs>();
            services.AddScoped<IIadeIslemRepository, IadeIslemRepository>();

            services.AddScoped<IRolBs, RolBs>();
            services.AddScoped<IRolRepository, RolRepository>();

            services.AddScoped<ICalisanBs, CalisanBs>();
            services.AddScoped<ICalisanRepository, CalisanRepository>();

            services.AddScoped<IUrunBs, UrunBs>();
            services.AddScoped<IUrunRepository, UrunRepository>();

            services.AddScoped<IRafBs, RafBs>();
            services.AddScoped<IRafRepository, RafRepository>();

            services.AddScoped<IMagazaBs, MagazaBs>();
            services.AddScoped<IMagazaRepository, MagazaRepository>();

            services.AddScoped<IKonumBs, KonumBs>();
            services.AddScoped<IKonumRepository, KonumRepository>();

            services.AddScoped<IKategoriBs, KategoriBs>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();

            services.AddScoped<IIslemTurBs, IslemTurBs>();
            services.AddScoped<IIslemTurRepository, IslemTurRepository>();

            services.AddScoped<IIslemBs, IslemBs>();
            services.AddScoped<IIslemRepository, IslemRepository>();

        }
    }
}
