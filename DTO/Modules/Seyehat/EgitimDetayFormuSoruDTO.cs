using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuSoruDTO
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public int? EgitimDetayFormuSoruBaslikId { get; set; }
        public string EgitimDetayFormuSoruBaslikTanim { get; set; }
        public int? CevapTuru { get; set; }
        public string CevapTuruAciklama { get; set; }
        public int? Sira { get; set; }
        public int? TxtSatirSayisi { get; set; }
    }
}
