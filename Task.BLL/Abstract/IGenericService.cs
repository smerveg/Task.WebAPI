using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.Abstract
{
    public interface IGenericService<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
    }
}
