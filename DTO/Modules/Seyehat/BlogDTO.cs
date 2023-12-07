using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modules.SeyehatWeb
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public int? KategoriId { get; set; }
        public string KategoriAciklama { get; set; }
        public string Resim { get; set; }
        public string Detay { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
