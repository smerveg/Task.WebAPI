using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.DTOs
{
    public class KategoriDTO
    {
        public int KategoriId { get; set; }
        public int? UstKategoriId { get; set; }      
        public string KategoriAd { get; set; }
    }
}
