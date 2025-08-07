using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Islem
{
    public class IslemGetDto : IDto
    {
        public int IslemId { get; set; }
        //public int IslemTurID { get; set; }
        public string IslemAdi { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
