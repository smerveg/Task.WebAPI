using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.Entities
{
    public class UrunSiparis
    {


        public int UrunId { get; set; }

        public int SiparisId { get; set; }
        public int Adet { get; set; }
        
    }
}
