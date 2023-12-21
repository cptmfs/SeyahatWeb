using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuSoruBaglantiDTO
    {
        public int Id { get; set; }
        public int? EgitimDetayFormuSoruId { get; set; }
        public string EgitimDetayFormuSoruAciklama { get; set; }
        public int? Tur { get; set; }
        public string TurAciklama { get; set; }
        public bool? Aktif { get; set; }
        public string AktifAciklama { get; set; }
    }
}
