using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLServer.Service
{
    public interface IRepositorio<T> : IDisposable where T : class, new()
    {

        //T GetPorId(int id);
        //T GetPorGuid(string guid);
        //void Adicionar(T entity);
        //void Atualizar(T entity);
        //void Deletar(T entity);
        //void Deletar(int id);

       
        T Insert(T model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(Expression<Func<T, bool>> where);
        bool Delete(params object[] Keys);
        T Find(params object[] Keys);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> Query();
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
        IQueryable<T> QueryFast();
        IQueryable<T> QueryFast(params Expression<Func<T, object>>[] includes);
        DbContext Context { get; }
        //DbSet<T> Model { get; }
        Int32 Save();
        Task<Int32> SaveAsync();


    }
}
