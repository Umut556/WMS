using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.Fabrika
{
    public class FabrikaPostDto : IDto
    {
        public string Adres { get; set; }
        public string TelefonNo { get; set; }

    }
}
