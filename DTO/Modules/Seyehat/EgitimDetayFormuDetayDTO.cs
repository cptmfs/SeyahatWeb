using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.Seyehat
{
    public class EgitimDetayFormuDetayDTO
    {
        public int Id { get; set; }
        public int? EgitimDetayFormuId { get; set; }
        public int? EgitimDetayFormuSoruBaglantiId { get; set; }
        public string Cevap { get; set; }
    }
}
