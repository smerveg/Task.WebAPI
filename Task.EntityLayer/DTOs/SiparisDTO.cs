using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.DTOs
{
    public class SiparisDTO
    {
        public int SiparisId { get; set; }
        //public int Adet { get; set; }
        public bool SatinAlindiMi { get; set; }
        public int KullaniciId { get; set; }
        public List<UrunListDTO> UrunList { get; set; }
    }
}
