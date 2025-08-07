using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Blok
{
    public class BlokGetDto : IDto
    {
        public int BlokId { get; set; }
        public string? BlokAdi { get; set; }
    }
}
