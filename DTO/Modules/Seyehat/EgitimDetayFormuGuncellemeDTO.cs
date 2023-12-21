using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuGuncellemeDTO
    {
        public int Id { get; set; }
        public int? EgitimDetayFormuId { get; set; }
        public string Aciklama { get; set; }
        public DateTime? OlusturulmaTarihi { get; set; }
        public int? OlusturanKullanici { get; set; }
        public string OlusturanKullaniciTanim { get; set; }
    }
}
