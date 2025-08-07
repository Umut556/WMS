using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Raf
{
    public class RafPostDto : IDto
    {
        public int BlokID { get; set; }
        public string? RafAdi { get; set; }
    }
}
