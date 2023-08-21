using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.Entities
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        //public int Adet { get; set; }
        public bool SatinAlindiMi { get; set; }

        //
        public ICollection<Urun> Uruns { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
    }
}
