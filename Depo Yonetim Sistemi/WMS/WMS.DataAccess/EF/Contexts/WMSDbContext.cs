using Microsoft.EntityFrameworkCore;
using WMS.Model.Entities;

namespace WMS.DataAccess.EF.Contexts
{
    public class WMSDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;database=WMS_DB;trusted_connection=true;");
        }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Blok> Bloklar { get; set; }
        public DbSet<Bolme> Bolmeler { get; set; }
        public DbSet<Fabrika> Fabrikalar { get; set; }
        public DbSet<GirisIslem> GirisIslemler { get; set; }
        public DbSet<CikisIslem> CikisIslemler { get; set; }
        public DbSet<IadeIslem> IadeIslemler { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<IslemTur> IslemTurler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Konum> Konumlar { get; set; }
        public DbSet<Magaza> Magazalar { get; set; }
        public DbSet<Raf> Raflar { get; set; }
        public DbSet<Urun> Urunler { get; set; }

    }
}
