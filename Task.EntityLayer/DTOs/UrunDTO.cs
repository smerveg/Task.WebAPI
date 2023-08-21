using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.DTOs
{
    public class UrunDTO
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public float Ucret { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }
        public string Gorsel { get; set; }
        public bool YayindaMi { get; set; }
        public int KategoriId { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }

    }
}
