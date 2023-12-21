using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuDTO
    {
        public int Id { get; set; }
        public int? KullaniciId { get; set; }
        public int SiraNo { get; set; }
        public string KullaniciAciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public bool? Aktif { get; set; }
        public DateTime? KapatmaTarihi { get; set; }
        public int? KapatanKullaniciId { get; set; }
        public string KapatanKullaniciAciklama { get; set; }
        public string AcanKullaniciAciklama { get; set; }
        public DateTime? AcmaTarihi { get; set; }
        public int? AcanKullaniciId { get; set; }
        public int? OlusturanKullanici { get; set; }
        public string OlusturanKullaniciTanim { get; set; }
        public string AktifAciklama { get; set; }
        public int? Tur { get; set; }
        public string TurAciklama { get; set; }
    }
}
