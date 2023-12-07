using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.SeyehatWeb
{
    public class GaleriDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public int? KategoriId { get; set; }
        public string KategoriAciklama { get; set; }
        public string Resim { get; set; }
    }
}
