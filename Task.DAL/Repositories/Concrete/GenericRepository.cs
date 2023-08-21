using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Context;
using Task.DAL.Repositories.Abstract;
using Task.EntityLayer.Entities;

namespace Task.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskContext context;
        string deneme = null;

        public GenericRepository(TaskContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public T AddUrunSiparis(T entity)
        {
            context.Set<T>("UrunSiparis").Add(entity);
            return entity;
        }

        public IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter=null)
        {
           return  context.Set<T>().Where(filter).ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).FirstOrDefault();
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            return entity;
        }

        public bool Exist(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Any(filter);            
        }

        public string PasswordHash(string password)
        {
            byte[] salt = new byte[1];
            salt[0] = 00000000;
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
