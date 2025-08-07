using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Kategori
{
    public class KategoriGetDto :IDto
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }
    }
}
