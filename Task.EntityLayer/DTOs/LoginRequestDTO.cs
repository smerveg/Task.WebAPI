using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.DTOs
{
    public class LoginRequestDTO
    {
        public string KullaniciAdi { get; set; }
        public int TelefonNo { get; set; }
        public string Sifre { get; set; }
       
    }
}
