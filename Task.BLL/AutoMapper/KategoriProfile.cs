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
    public class KategoriProfile:Profile
    {
        public KategoriProfile()
        {
            CreateMap<Kategori, KategoriDTO>().ReverseMap();
        }
    }
}
