using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.DTOs;

namespace Task.BLL.Abstract
{
    public interface ITokenService
    {
        LoginResponseDTO GenerateToken(string rol);
    }
}
