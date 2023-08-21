using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.Entities
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public int? UstKategoriId { get; set; }        
        public string KategoriAd { get; set; }

        //
        public ICollection<Urun> Uruns { get; set; }


    }
}
