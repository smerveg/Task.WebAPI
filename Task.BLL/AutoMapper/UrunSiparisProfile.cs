using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.AutoMapper
{
    public class UrunSiparisProfile:Profile
    {
        public UrunSiparisProfile()
        {
            CreateMap<UrunSiparis, UrunSiparisDTO>().ReverseMap();
        }
    }
}
