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
    public class SiparisService : ISiparisService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SiparisService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public SiparisDTO Add(SiparisDTO entity)
        {

            var urunList = entity.UrunList;
            SiparisDTO siparisDto = new SiparisDTO
            {
               SatinAlindiMi=false,
               KullaniciId=entity.KullaniciId

            };

            Siparis siparis = new Siparis();
            siparis = mapper.Map<SiparisDTO, Siparis>(siparisDto);
            unitOfWork.GetRepository<Siparis>().Add(siparis);
            int siparisId=unitOfWork.Save();

            foreach (var item in urunList)
            {
                UrunSiparisDTO urunSiparisDto = new UrunSiparisDTO
                {
                    UrunId = item.UrunId,
                    SiparisId = siparis.SiparisId,
                    Adet=item.Adet
                    
                };
                UrunSiparis urunSiparis = new UrunSiparis();
                urunSiparis = mapper.Map<UrunSiparisDTO, UrunSiparis>(urunSiparisDto);
                unitOfWork.GetRepository<UrunSiparis>().AddUrunSiparis(urunSiparis);

            }
            unitOfWork.Save();
            return entity;
        }

        public IEnumerable<SiparisDTO> GetAll()
        {
            return unitOfWork.GetRepository<SiparisDTO>().GetAll();
        }

        public SiparisDTO Buy(int id)
        {
            Siparis result =unitOfWork.GetRepository<Siparis>().GetByFilter(x => x.SiparisId == id);

            if (result!=null)
            {
                result.SatinAlindiMi = true;
                SiparisDTO siparisDTO = new SiparisDTO();
                siparisDTO=mapper.Map<Siparis,SiparisDTO>(result);        
                unitOfWork.GetRepository<Siparis>().Update(result);

                return siparisDTO;
            }
            else
            {
                SiparisDTO siparisDTO = new SiparisDTO();
                siparisDTO = mapper.Map<Siparis, SiparisDTO>(result);
                return siparisDTO;
            }
            
            
        }
    }
}
