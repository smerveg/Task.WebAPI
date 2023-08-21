using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Abstract;
using Task.DAL.Context;
using Task.DAL.UnitOfWorks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.Concrete
{
    public class UrunService : IUrunService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
       

        public UrunService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
           
        }
        public UrunDTO Add(UrunDTO entity)
        {
            entity.YayindaMi = false;
            Urun urun = new Urun();           
            urun = mapper.Map<UrunDTO, Urun>(entity);
            unitOfWork.GetRepository<Urun>().Add(urun);
            unitOfWork.Save();
            return entity;
            
        }

        public UrunDTO Cancel(int id)
        {
            Urun result = unitOfWork.GetRepository<Urun>().GetByFilter(x => x.UrunId == id);

            if (result != null)
            {
                result.YayindaMi = false;
                UrunDTO urunDTO = new UrunDTO();
                urunDTO = mapper.Map<Urun, UrunDTO>(result);
                unitOfWork.GetRepository<Urun>().Update(result);

                return urunDTO;
            }
            else
            {
                UrunDTO urunDTO = new UrunDTO();
                urunDTO = mapper.Map<Urun, UrunDTO>(result);
                return urunDTO;
            }
        }

        public IEnumerable<UrunDTO> GetAll()
        {
            var urunList=unitOfWork.GetRepository<Urun>().GetAll();
            return mapper.Map<List<UrunDTO>>(urunList);
        }

        public IEnumerable<UrunDTO> GetAllByFilter(Expression<Func<Urun, bool>> filter)
        {
            var urunList=unitOfWork.GetRepository<Urun>().GetAllByFilter(filter);
            return mapper.Map<List<UrunDTO>>(urunList);

        }

        public UrunDTO Publish(int id)
        {
            Urun result = unitOfWork.GetRepository<Urun>().GetByFilter(x => x.UrunId == id);

            if (result != null)
            {
                result.YayindaMi = true;
                UrunDTO urunDTO = new UrunDTO();
                urunDTO = mapper.Map<Urun, UrunDTO>(result);
                unitOfWork.GetRepository<Urun>().Update(result);

                return urunDTO;
            }
            else
            {
                UrunDTO urunDTO = new UrunDTO();
                urunDTO = mapper.Map<Urun, UrunDTO>(result);
                return urunDTO;
            }
        }

        public UrunDTO Update(UrunDTO entity)
        {
            Urun urun = new Urun();
            urun = mapper.Map<UrunDTO, Urun>(entity);
            unitOfWork.GetRepository<Urun>().Update(urun);
            return entity;

            
        }

        public bool UrunExist(int id)
        {
            return unitOfWork.GetRepository<Urun>().Exist(x=>x.UrunId==id);

        }



    }
}
