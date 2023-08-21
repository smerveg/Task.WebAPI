using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.Entities;

namespace Task.EntityLayer.DTOs
{
    public class UrunSiparisDTO
    {
        public int UrunId { get; set; }
        public int SiparisId { get; set; }
        public int Adet { get; set; }

    }
}
