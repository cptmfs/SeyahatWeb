using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuSoruSecenekleriDTO
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public int? EgitimDetayFormuSoruId { get; set; }
        public string EgitimDetayFormuSoruTanim { get; set; }
        public int? Sira { get; set; }
    }
}
