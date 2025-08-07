using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Dtos.IslemTur
{
    public class IslemTurGetDto : IDto
    {
        public int IslemTurId { get; set; }
        public string IslemAdi { get; set; }
    }
}
