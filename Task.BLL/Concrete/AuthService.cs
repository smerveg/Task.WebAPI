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
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public string Login(LoginRequestDTO request)
        {
            string rol = "";

            if (request.KullaniciAdi=="" && request.TelefonNo!=0)
            {                
                var kullanici= unitOfWork.GetRepository<Kullanici>().GetByFilter(x => x.Telefon == request.TelefonNo);
                if (kullanici != null)
                {
                    var sifre = unitOfWork.GetRepository<Kullanici>().PasswordHash(request.Sifre);

                    if (sifre.Equals(kullanici.Sifre))
                    {
                    
                        rol= kullanici.KullaniciRol;
                    }
                }

            }
            else
            {
                var kullanici = unitOfWork.GetRepository<Kullanici>().GetByFilter(x => x.KullaniciAdi == request.KullaniciAdi);
                if (kullanici != null)
                {
                    var sifre = unitOfWork.GetRepository<Kullanici>().PasswordHash(request.Sifre);

                    if (sifre.Equals(kullanici.Sifre))
                    {

                        rol = kullanici.KullaniciRol;
                    }
                }

            }


            return rol;





        }
    }
}
