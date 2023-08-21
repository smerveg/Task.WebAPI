using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.EntityLayer.DTOs;
using Task.EntityLayer.Entities;

namespace Task.BLL.Abstract
{
    public interface IUrunService:IGenericService<UrunDTO>
    {
        IEnumerable<UrunDTO> GetAllByFilter(Expression<Func<Urun, bool>> filter);

        UrunDTO Update(UrunDTO entity);
        UrunDTO Publish(int urunId);
        UrunDTO Cancel(int urunId);
        bool UrunExist(int id);
    }
}
