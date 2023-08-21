using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
    public class KullaniciService : IKullaniciService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public KullaniciService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public KullaniciDTO Add(KullaniciDTO entity)
        {
            
            Kullanici kullanici = new Kullanici();
            kullanici = mapper.Map<KullaniciDTO, Kullanici>(entity);
            kullanici.Sifre = PasswordHash(entity.Sifre);
            unitOfWork.GetRepository<Kullanici>().Add(kullanici);
            unitOfWork.Save();
            return entity;
        }

        public IEnumerable<KullaniciDTO> GetAll()
        {
            var kullaniciList=unitOfWork.GetRepository<Kullanici>().GetAll();
            return mapper.Map<List<KullaniciDTO>>(kullaniciList);
        }

        public bool KullaniciExist(int TCNo)
        {
            return unitOfWork.GetRepository<Kullanici>().Exist(x=>x.TCKimlikNo==TCNo);
        }

        public  string PasswordHash(string password)
        {
            byte[] salt = new byte[1];
            salt[0] = 00000000 ;
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));
            return hashed;
        }
    }
}
