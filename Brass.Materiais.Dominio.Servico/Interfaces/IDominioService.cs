using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Interfaces
{


    public interface IDominioService<T>: IDisposable where T : class, new()
    {

        void Start(string connectionString);
        SQLiteConnection GetConnection();
        long Add(T entity);
        void AddRange(IList<T> entities);
        void Update(T entity);
        void UpdateRange(IList<T> entities);
        T GetById(object id);
        IList<T> Find(IEnumerable<object> ids);
        IList<T> Find(IFilter<T> filter);
        IList<T> GetAll();
        IList<T> GetAll(string commandText);
        IList<TEntity> GetAll<TEntity>(string commandText)
            where TEntity : class, new();

    }
}
