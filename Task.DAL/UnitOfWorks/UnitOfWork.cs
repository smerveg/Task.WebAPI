using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Context;
using Task.DAL.Repositories.Abstract;
using Task.DAL.Repositories.Concrete;

namespace Task.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext context;

        public UnitOfWork(TaskContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
