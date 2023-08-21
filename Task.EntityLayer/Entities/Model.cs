using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.Entities
{
    public  class Model
    {
        public int ModelId { get; set; }
        [Required]
        public string ModelAd { get; set; }

        //
        public ICollection<Urun> Uruns  { get; set; }
    }
}
