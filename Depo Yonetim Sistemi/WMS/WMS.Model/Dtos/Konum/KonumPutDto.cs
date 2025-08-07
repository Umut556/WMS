using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Konum
{
    public class KonumPutDto :IDto
    {
        public int KonumId { get; set; }
        public int BlokID { get; set; }
        public int RafID { get; set; }
        public int BolmeID { get; set; }
    }
}
