using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.Abstract
{
    public  interface IKullaniciService:IGenericService<KullaniciDTO>
    {
        bool KullaniciExist(int TCNo);
        string PasswordHash(string password);
    }
}
