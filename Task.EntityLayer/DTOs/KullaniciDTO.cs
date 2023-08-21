using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.EntityLayer.DTOs
{
    public class KullaniciDTO
    {

        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "TC Kimlik no alanı boş geçilemez.")]
        public int TCKimlikNo { get; set; }
        [Required(ErrorMessage = "Mail alanı boş geçilemez.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Sifre alanı boş geçilemez.")]
        public string Sifre { get; set; }

    }
}
