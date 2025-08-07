using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Entities
{
    public class Islem : IEntity
    {
        public int IslemId { get; set; }
        public int IslemTurID { get; set; }
        public DateTime IslemTarihi { get; set;}

        public IslemTur IslemTur { get; set; }

    }
}
