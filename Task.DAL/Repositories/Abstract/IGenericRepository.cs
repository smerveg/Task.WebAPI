using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Repositories.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
       
        T Add(T entity);
        T AddUrunSiparis(T entity);
        IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter=null);
        T GetByFilter(Expression<Func<T, bool>> filter);
        T Update(T entity);
        //UrunDTO Publish(UrunDTO urun);
        //UrunDTO Cancel(UrunDTO urun);
        bool Exist(Expression<Func<T, bool>> filter);
        string PasswordHash(string password);

    }
}
