using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Abstract;
using Task.DAL.UnitOfWorks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.Concrete
{
    public class MarkaService : IMarkaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MarkaService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public MarkaDTO Add(MarkaDTO entity)
        {
            Marka marka = new Marka();
            marka = mapper.Map<MarkaDTO, Marka>(entity);
            unitOfWork.GetRepository<Marka>().Add(marka);
            unitOfWork.Save();
            return entity;
        }

        public IEnumerable<MarkaDTO> GetAll()
        {
            
            var markaList=unitOfWork.GetRepository<Marka>().GetAll();
            return mapper.Map<List<MarkaDTO>>(markaList);
        }
    }
}
