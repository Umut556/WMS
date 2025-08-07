using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Islem
{
    public class IslemPostDto : IDto
    {
        public int IslemTurID { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
