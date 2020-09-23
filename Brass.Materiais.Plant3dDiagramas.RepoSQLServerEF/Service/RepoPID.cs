using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Plant3dDiagramas.RepoSQLServerEF.Service
{
    public class RepoPID<T> : IRepoPID<T> where T : class, new()
    {
        protected DbContext _contexto;
        //protected CatalogoBRASSEntities _catalogoBRASSEntities;
        protected DbSet<T> _model;





        public RepoPID(string conexaoString, string database)
        {
            //name=DataBaseContext

            //string strContexto = conexaoString.Split('=')[1];
            switch (conexaoString)
            {
         
       
                case "Plant3d_Diagramas":
                    _contexto = new Plant3d_PnIdEntities();
                    break;

                    //case "Azure":
                    //{
                    //_contexto = new CatalogoBRASSEntities();  
                    //}
                    //break;
            }

            _model = _contexto.Set<T>();
            //if (_dbContext == null) throw new NullReferenceException("dbContext");
            //_contexto = _dbContext;

        }

        public T Insert(T model)
        {
            _model.Add(model);
            this.Save();
            return model;
        }
        public bool Edit(T model)
        {
            bool status = false;
            _contexto.Entry<T>(model).State = EntityState.Modified;
            if (this.Save() > 0)
            {
                status = true;
            }
            return status;
        }
        public bool Delete(T model)
        {
            bool status = false;
            _contexto.Entry<T>(model).State = EntityState.Deleted;
            if (this.Save() > 0)
            {
                status = true;
            }
            return status;
        }
        public bool Delete(Expression<Func<T, bool>> where)
        {
            bool status = false;
            T model = _model.Where<T>(where).FirstOrDefault<T>();
            if (model != null)
            {
                status = Delete(model);
            }
            return status;
        }
        public bool Delete(params object[] Keys)
        {
            bool status = false;
            T model = _model.Find(Keys);
            if (model != null)
            {
                status = Delete(model);
            }
            return status;
        }
        public T Find(params object[] Keys)
        {
            return _model.Find(Keys);
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _model.Where<T>(where).FirstOrDefault<T>();
        }
        public IQueryable<T> Query()
        {
            return _model;
        }
        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> Set = this.Query();
            foreach (var include in includes)
            {
                Set = Set.Include(include);
            }
            return Set;
        }
        public IQueryable<T> QueryFast()
        {
            return _model.AsNoTracking<T>();
        }
        public IQueryable<T> QueryFast(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> Set = this.QueryFast();
            foreach (var include in includes)
            {
                Set = Set.Include(include);
            }
            return Set.AsNoTracking();

        }
        public T Create()
        {
            return _model.Create();
        }

        //public DbSet<T> Model
        //{
        //    get;
        //    private set;
        //}

        public DbContext Context => throw new NotImplementedException();

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        public int Save()
        {
            return _contexto.SaveChanges();
        }
        public async System.Threading.Tasks.Task<int> SaveAsync()
        {
            return await _contexto.SaveChangesAsync();
        }
    }
}
