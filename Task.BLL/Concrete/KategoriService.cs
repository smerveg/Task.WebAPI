using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Abstract;
using Task.DAL.Context;
using Task.DAL.UnitOfWorks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.Concrete
{
    public class KategoriService : IKategoriService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly TaskContext context;

        public KategoriService(IUnitOfWork unitOfWork, IMapper mapper,TaskContext context)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.context = context;
        }
        public KategoriDTO Add(KategoriDTO entity)
        {
            Kategori kategori = new Kategori();
            kategori = mapper.Map<KategoriDTO, Kategori>(entity);
            unitOfWork.GetRepository<Kategori>().Add(kategori);
            unitOfWork.Save();
            return entity;
        }

        public IEnumerable<KategoriDTO> GetAll()
        {

            var kategoriList = unitOfWork.GetRepository<Kategori>().GetAll();
            return mapper.Map<List<KategoriDTO>>(kategoriList);
        }

        public bool KategoriExist(int id)
        {
            return unitOfWork.GetRepository<Kategori>().Exist(x=>x.KategoriId==id);
       
        }
    }
}
