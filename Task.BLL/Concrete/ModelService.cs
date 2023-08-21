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
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ModelService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ModelDTO Add(ModelDTO entity)
        {
            Model model = new Model();
            model = mapper.Map<ModelDTO, Model>(entity);
            unitOfWork.GetRepository<Model>().Add(model);
            unitOfWork.Save();
            return entity;
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            var modelList=unitOfWork.GetRepository<Model>().GetAll();
            return mapper.Map<List<ModelDTO>>(modelList);
        }
    }
}
