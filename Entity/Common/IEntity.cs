using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{
    public  interface IEntity
    {
         int Id { get; set; }
         int? OlusturanKullanici { get; set; }

        int? GuncelleyenKullanici { get; set; }


        DateTime? OlusturulmaTarihi { get; set; }

        DateTime? GuncellestirilmeTarihi { get; set; }

        bool Silindi { get; set; }
    }
}
