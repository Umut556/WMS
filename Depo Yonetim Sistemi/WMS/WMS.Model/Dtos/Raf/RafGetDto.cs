using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Raf
{
    public class RafGetDto : IDto
    {
        public int RafId { get; set; }
        //public int BlokID { get; set; }
        public string? BlokAdi { get; set; }
        public string? RafAdi { get; set; }
    }
}
