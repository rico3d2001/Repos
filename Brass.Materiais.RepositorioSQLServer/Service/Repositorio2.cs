using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLServer.Service
{
    public class Repositorio2<T> : IRepositorio<T> where T : class, new()
    {
        public DbContext Context => throw new NotImplementedException();

        public bool Delete(T model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public bool Delete(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Edit(T model)
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T Insert(T model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryFast()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryFast(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
